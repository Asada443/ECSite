using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using ShoppingSite_a.DTO;

namespace ShoppingSite_a.DAO
{
    public class OrderDAO
    {
        private string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

        /// <summary>
        /// 購入処理（注文登録 ＋ 在庫減算）をトランザクションで実行する
        /// </summary>
        public int InsertOrder(OrderDTO order)
        {
            int generatedOrderId = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // トランザクションの開始
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. T_ORDER テーブルに注文の親情報を登録
                    // SQLのカラム名を MEMBER_ID ➔ USER_ID に変更
                    string orderSql = @"
                        INSERT INTO T_ORDER (USER_ID, TOTAL_PRICE, TAX, CREATED_AT)
                        VALUES (@UserId, @TotalPrice, @Tax, GETDATE());
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmdOrder = new SqlCommand(orderSql, conn, transaction);
                    // order.MemberId ➔ order.UserId に書き換え
                    cmdOrder.Parameters.AddWithValue("@UserId", order.UserId);
                    cmdOrder.Parameters.AddWithValue("@TotalPrice", order.TotalPrice);
                    cmdOrder.Parameters.AddWithValue("@Tax", order.Tax);

                    generatedOrderId = Convert.ToInt32(cmdOrder.ExecuteScalar());

                    // 2. カートの商品数だけループして明細登録と在庫減算
                    foreach (var detail in order.Details)
                    {
                        // 2-a. T_ORDER_DETAIL テーブルに明細を登録
                        string detailSql = @"
                            INSERT INTO T_ORDER_DETAIL (ORDER_ID, PRODUCT_ID, QUANTITY, PRICE)
                            VALUES (@OrderId, @ProductId, @Quantity, @Price)";

                        SqlCommand cmdDetail = new SqlCommand(detailSql, conn, transaction);
                        cmdDetail.Parameters.AddWithValue("@OrderId", generatedOrderId);
                        cmdDetail.Parameters.AddWithValue("@ProductId", detail.ProductId);
                        cmdDetail.Parameters.AddWithValue("@Quantity", detail.Quantity);
                        cmdDetail.Parameters.AddWithValue("@Price", detail.Price);
                        cmdDetail.ExecuteNonQuery();

                        // 2-b. products テーブルの STOCK（在庫数）を減算
                        string stockSql = @"
                            UPDATE products 
                            SET STOCK = STOCK - @Quantity 
                            WHERE PRODUCT_ID = @ProductId";

                        SqlCommand cmdStock = new SqlCommand(stockSql, conn, transaction);
                        cmdStock.Parameters.AddWithValue("@Quantity", detail.Quantity);
                        cmdStock.Parameters.AddWithValue("@ProductId", detail.ProductId);
                        cmdStock.ExecuteNonQuery();
                    }

                    // すべて成功したら確定
                    transaction.Commit();
                }
                catch (Exception)
                {
                    // どこかで失敗したら巻き戻す
                    transaction.Rollback();
                    throw;
                }
            }
            return generatedOrderId;
        }

        /// <summary>
        /// 購入完了画面用：今確定した注文情報をデータベースから取得する
        /// </summary>
        public OrderDTO GetOrderCompleteData(int orderId)
        {
            OrderDTO order = null;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // ① 親情報の取得
                string orderSql = "SELECT * FROM T_ORDER WHERE ORDER_ID = @OrderId";
                SqlCommand cmd = new SqlCommand(orderSql, conn);
                cmd.Parameters.AddWithValue("@OrderId", orderId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order = new OrderDTO
                        {
                            OrderId = (int)reader["ORDER_ID"],
                            // データベースから取得する部分も USER_ID を見るように修正
                            UserId = reader["USER_ID"].ToString(),
                            TotalPrice = (int)reader["TOTAL_PRICE"],
                            Tax = (int)reader["TAX"],
                            CreatedAt = Convert.ToDateTime(reader["CREATED_AT"])
                        };
                    }
                }

                if (order == null) return null;

                // ② 明細情報の取得（productsテーブルと結合して商品名を取る）
                string detailSql = @"
                    SELECT d.*, p.PRODUCT_NAME 
                    FROM T_ORDER_DETAIL d
                    INNER JOIN products p ON d.PRODUCT_ID = p.PRODUCT_ID
                    WHERE d.ORDER_ID = @OrderId";

                SqlCommand cmdDetail = new SqlCommand(detailSql, conn);
                cmdDetail.Parameters.AddWithValue("@OrderId", orderId);

                using (SqlDataReader reader = cmdDetail.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        order.Details.Add(new OrderDetailDTO
                        {
                            ProductName = reader["PRODUCT_NAME"].ToString(),
                            Price = (int)reader["PRICE"],
                            Quantity = (int)reader["QUANTITY"]
                        });
                    }
                }
            }
            return order;
        }

        /* 購入履歴画面用：ログイン中の宇宙会員IDに紐づく注文履歴一覧を取得する（新しい順）*/
        // 引数の型名を memberId ➔ userId に変更！
        public List<OrderDTO> GetOrderHistoryByUserId(string userId)
        {
            List<OrderDTO> historyList = new List<OrderDTO>();

            //  SQLのカラム名を MEMBER_ID ➔ USER_ID に変更！
            string sql = @"
                SELECT ORDER_ID, USER_ID, TOTAL_PRICE, TAX, CREATED_AT 
                FROM T_ORDER 
                WHERE USER_ID = @UserId 
                ORDER BY CREATED_AT DESC";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // パラメータを @UserId にバインド
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderDTO order = new OrderDTO
                            {
                                OrderId = Convert.ToInt32(reader["ORDER_ID"]),
                                // プロパティ名および読込先を UserId に！
                                UserId = reader["USER_ID"].ToString(),
                                TotalPrice = Convert.ToInt32(reader["TOTAL_PRICE"]),
                                Tax = Convert.ToInt32(reader["TAX"]),
                                CreatedAt = Convert.ToDateTime(reader["CREATED_AT"])
                            };
                            historyList.Add(order);
                        }
                    }
                }
            }
            return historyList;
        }
    }
}