using ShoppingSite_a.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace ShoppingSite_a.DAO
{
    /// <summary>
    /// 商品テーブル（products）に関するデータベース操作（SQL実行）を専門に行うクラス
    /// </summary>
    public class ProductDAO
    {
        /// <summary>
        /// 【全件取得】登録されているすべての商品を、登録が新しい順（CREATED_AT DESC）に取得します。
        /// </summary>
        public List<ProductDTO> GetAll()
        {
            List<ProductDTO> list = new List<ProductDTO>();
            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT PRODUCT_ID, PRODUCT_NAME, PRICE, PLANET, STOCK, DESCRIPTION, IMAGE_PATH, RECOMMENDED_ENVIRONMENT, CREATED_AT
                    FROM products
                    ORDER BY CREATED_AT DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductDTO p = new ProductDTO();
                        p.ProductId = (int)reader["PRODUCT_ID"];
                        p.ProductName = reader["PRODUCT_NAME"].ToString();
                        p.Price = (int)reader["PRICE"];
                        p.Planet = reader["PLANET"].ToString();
                        p.Stock = (int)reader["STOCK"];
                        p.Description = reader["DESCRIPTION"] == DBNull.Value ? "" : reader["DESCRIPTION"].ToString();
                        p.ImagePath = reader["IMAGE_PATH"] == DBNull.Value ? "" : reader["IMAGE_PATH"].ToString();
                        p.RecommendedEnvironment = reader["RECOMMENDED_ENVIRONMENT"] == DBNull.Value ? "" : reader["RECOMMENDED_ENVIRONMENT"].ToString();
                        p.CreatedAt = (DateTime)reader["CREATED_AT"];
                        list.Add(p);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 【並び替え付き全件取得】一般画面用：指定された条件でソートして全商品を取得します。
        /// </summary>
        public List<ProductDTO> GetAll(string sortType)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            string orderBy = "CREATED_AT DESC";

            if (sortType == "NEW") orderBy = "CREATED_AT DESC";
            else if (sortType == "PRICE_ASC") orderBy = "PRICE ASC";
            else if (sortType == "PRICE_DESC") orderBy = "PRICE DESC";
            // 日本語辞書順を指定（Japanese_XJIS_100_CI_AS）
            else if (sortType == "NAME_ASC") orderBy = "PRODUCT_NAME COLLATE Japanese_XJIS_100_CI_AS ASC";
            else if (sortType == "NAME_DESC") orderBy = "PRODUCT_NAME COLLATE Japanese_XJIS_100_CI_AS DESC";
            // 在庫順を追加
            else if (sortType == "STOCK_ASC") orderBy = "STOCK ASC";
            else if (sortType == "STOCK_DESC") orderBy = "STOCK DESC";

            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = $@"
                    SELECT PRODUCT_ID, PRODUCT_NAME, PRICE, PLANET, STOCK, DESCRIPTION, IMAGE_PATH, RECOMMENDED_ENVIRONMENT, CREATED_AT
                    FROM products
                    ORDER BY {orderBy}";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductDTO p = new ProductDTO();
                        p.ProductId = (int)reader["PRODUCT_ID"];
                        p.ProductName = reader["PRODUCT_NAME"].ToString();
                        p.Price = (int)reader["PRICE"];
                        p.Planet = reader["PLANET"].ToString();
                        p.Stock = (int)reader["STOCK"];
                        p.Description = reader["DESCRIPTION"] == DBNull.Value ? "" : reader["DESCRIPTION"].ToString();
                        p.ImagePath = reader["IMAGE_PATH"] == DBNull.Value ? "" : reader["IMAGE_PATH"].ToString();
                        p.RecommendedEnvironment = reader["RECOMMENDED_ENVIRONMENT"] == DBNull.Value ? "" : reader["RECOMMENDED_ENVIRONMENT"].ToString();
                        p.CreatedAt = (DateTime)reader["CREATED_AT"];
                        list.Add(p);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 【あいまい検索】商品名に入力されたキーワードが含まれる商品を探します（新着順）。
        /// </summary>
        public List<ProductDTO> Search(string keyword)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT PRODUCT_ID, PRODUCT_NAME, PRICE, PLANET, STOCK, DESCRIPTION, IMAGE_PATH, RECOMMENDED_ENVIRONMENT, CREATED_AT
                    FROM products
                    WHERE PRODUCT_NAME LIKE @keyword
                    ORDER BY CREATED_AT DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductDTO p = new ProductDTO();
                            p.ProductId = (int)reader["PRODUCT_ID"];
                            p.ProductName = reader["PRODUCT_NAME"].ToString();
                            p.Price = (int)reader["PRICE"];
                            p.Planet = reader["PLANET"].ToString();
                            p.Stock = (int)reader["STOCK"];
                            p.Description = reader["DESCRIPTION"] == DBNull.Value ? "" : reader["DESCRIPTION"].ToString();
                            p.ImagePath = reader["IMAGE_PATH"] == DBNull.Value ? "" : reader["IMAGE_PATH"].ToString();
                            p.RecommendedEnvironment = reader["RECOMMENDED_ENVIRONMENT"] == DBNull.Value ? "" : reader["RECOMMENDED_ENVIRONMENT"].ToString();
                            p.CreatedAt = (DateTime)reader["CREATED_AT"];
                            list.Add(p);
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 【並び替え付き・あいまい検索】キーワード検索結果を並び替えて取得します。
        /// </summary>
        public List<ProductDTO> Search(string keyword, string sortType)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            string orderBy = "CREATED_AT DESC";

            if (sortType == "PRICE_ASC") orderBy = "PRICE ASC";
            else if (sortType == "PRICE_DESC") orderBy = "PRICE DESC";
            else if (sortType == "NAME_ASC") orderBy = "PRODUCT_NAME ASC";
            else if (sortType == "NAME_DESC") orderBy = "PRODUCT_NAME DESC";

            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = $@"
                    SELECT PRODUCT_ID, PRODUCT_NAME, PRICE, PLANET, STOCK, DESCRIPTION, IMAGE_PATH, RECOMMENDED_ENVIRONMENT, CREATED_AT
                    FROM products
                    WHERE PRODUCT_NAME LIKE @keyword
                    ORDER BY {orderBy}";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductDTO p = new ProductDTO();
                            p.ProductId = (int)reader["PRODUCT_ID"];
                            p.ProductName = reader["PRODUCT_NAME"].ToString();
                            p.Price = (int)reader["PRICE"];
                            p.Planet = reader["PLANET"].ToString();
                            p.Stock = (int)reader["STOCK"];
                            p.Description = reader["DESCRIPTION"] == DBNull.Value ? "" : reader["DESCRIPTION"].ToString();
                            p.ImagePath = reader["IMAGE_PATH"] == DBNull.Value ? "" : reader["IMAGE_PATH"].ToString();
                            p.RecommendedEnvironment = reader["RECOMMENDED_ENVIRONMENT"] == DBNull.Value ? "" : reader["RECOMMENDED_ENVIRONMENT"].ToString();
                            p.CreatedAt = (DateTime)reader["CREATED_AT"];
                            list.Add(p);
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 【1件取得】商品ID（主キー）を元に、商品の詳しい情報を1件だけ取得します。
        /// </summary>
        public ProductDTO GetById(int productId)
        {
            ProductDTO p = null;
            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT PRODUCT_ID, PRODUCT_NAME, PRICE, PLANET, STOCK, DESCRIPTION, IMAGE_PATH, RECOMMENDED_ENVIRONMENT, CREATED_AT
                    FROM products
                    WHERE PRODUCT_ID = @productId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@productId", productId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            p = new ProductDTO();
                            p.ProductId = (int)reader["PRODUCT_ID"];
                            p.ProductName = reader["PRODUCT_NAME"].ToString();
                            p.Price = (int)reader["PRICE"];
                            p.Planet = reader["PLANET"].ToString();
                            p.Stock = (int)reader["STOCK"];
                            p.Description = reader["DESCRIPTION"] == DBNull.Value ? "" : reader["DESCRIPTION"].ToString();
                            p.ImagePath = reader["IMAGE_PATH"] == DBNull.Value ? "" : reader["IMAGE_PATH"].ToString();
                            p.RecommendedEnvironment = reader["RECOMMENDED_ENVIRONMENT"] == DBNull.Value ? "" : reader["RECOMMENDED_ENVIRONMENT"].ToString();
                            p.CreatedAt = (DateTime)reader["CREATED_AT"];
                        }
                    }
                }
            }
            return p;
        }

        /// <summary>
        /// 【新規登録】画面から入力された商品データをデータベースに保存します。
        /// </summary>
        public void Insert(ProductDTO p)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    INSERT INTO products (PRODUCT_NAME, PRICE, PLANET, STOCK, DESCRIPTION, IMAGE_PATH, RECOMMENDED_ENVIRONMENT, CREATED_AT)
                    VALUES (@productName, @price, @planet, @stock, @description, @imagePath, @recommendedEnvironment, GETDATE())";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@productName", p.ProductName);
                    cmd.Parameters.AddWithValue("@price", p.Price);
                    cmd.Parameters.AddWithValue("@planet", p.Planet);
                    cmd.Parameters.AddWithValue("@stock", p.Stock);
                    cmd.Parameters.AddWithValue("@description", p.Description ?? "");
                    cmd.Parameters.AddWithValue("@imagePath", p.ImagePath);
                    cmd.Parameters.AddWithValue("@recommendedEnvironment", p.RecommendedEnvironment ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 商品情報を更新する（UPDATE）
        /// </summary>
        public void Update(ProductDTO product)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (var connection = new SqlConnection(connStr))
            {
                string sql = @"
                    UPDATE products
                    SET PRODUCT_NAME = @ProductName, PRICE = @Price, STOCK = @Stock, PLANET = @Planet, DESCRIPTION = @Description, IMAGE_PATH = @ImagePath, RECOMMENDED_ENVIRONMENT = @RecommendedEnvironment
                    WHERE PRODUCT_ID = @ProductId";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@Planet", product.Planet);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@RecommendedEnvironment", product.RecommendedEnvironment);
                    command.Parameters.AddWithValue("@ImagePath", product.ImagePath);
                    command.Parameters.AddWithValue("@ProductId", product.ProductId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 商品を削除する（DELETE）
        /// </summary>
        public void Delete(int productId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            using (var connection = new SqlConnection(connStr))
            {
                string sql = "DELETE FROM products WHERE PRODUCT_ID = @ProductId";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 未ログイン用：人気商品トップ3を取得する（在庫が少ない順）
        /// </summary>
        public List<ProductDTO> GetPopularProducts()
        {
            List<ProductDTO> list = new List<ProductDTO>();
            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            string sql = @"SELECT TOP 3 PRODUCT_ID, PRODUCT_NAME, PRICE, PLANET, STOCK, DESCRIPTION, IMAGE_PATH, RECOMMENDED_ENVIRONMENT 
                           FROM products ORDER BY STOCK ASC";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductDTO dto = new ProductDTO();
                        dto.ProductId = Convert.ToInt32(reader["PRODUCT_ID"]);
                        dto.ProductName = reader["PRODUCT_NAME"].ToString();
                        dto.Price = Convert.ToInt32(reader["PRICE"]);
                        dto.Planet = reader["PLANET"].ToString();
                        dto.Stock = Convert.ToInt32(reader["STOCK"]);
                        dto.Description = reader["DESCRIPTION"] == DBNull.Value ? "" : reader["DESCRIPTION"].ToString();
                        dto.ImagePath = reader["IMAGE_PATH"] == DBNull.Value ? "" : reader["IMAGE_PATH"].ToString();
                        dto.RecommendedEnvironment = reader["RECOMMENDED_ENVIRONMENT"] == DBNull.Value ? "" : reader["RECOMMENDED_ENVIRONMENT"].ToString();
                        list.Add(dto);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// ログイン中用：ご希望の移住環境に一致するおすすめ商品を全件取得する
        /// </summary>
        
        public List<ProductDTO> GetRecommendedProducts(string recommendedEnvironment)
        {
            List<ProductDTO> list = new List<ProductDTO>();
            string connStr = ConfigurationManager.ConnectionStrings["ShoppingSiteDB"].ConnectionString;

            string sql = @"SELECT PRODUCT_ID, PRODUCT_NAME, PRICE, PLANET, STOCK, DESCRIPTION, IMAGE_PATH, RECOMMENDED_ENVIRONMENT 
                           FROM products 
                           WHERE RECOMMENDED_ENVIRONMENT = @RecommendedEnvironment
                           ORDER BY PRODUCT_ID DESC";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // パラメータ名も @RecommendedEnvironment に統一
                cmd.Parameters.AddWithValue("@RecommendedEnvironment", recommendedEnvironment ?? (object)DBNull.Value);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProductDTO dto = new ProductDTO();
                        dto.ProductId = Convert.ToInt32(reader["PRODUCT_ID"]);
                        dto.ProductName = reader["PRODUCT_NAME"].ToString();
                        dto.Price = Convert.ToInt32(reader["PRICE"]);
                        dto.Planet = reader["PLANET"].ToString();
                        dto.Stock = Convert.ToInt32(reader["STOCK"]);
                        dto.Description = reader["DESCRIPTION"] == DBNull.Value ? "" : reader["DESCRIPTION"].ToString();
                        dto.ImagePath = reader["IMAGE_PATH"] == DBNull.Value ? "" : reader["IMAGE_PATH"].ToString();
                        dto.RecommendedEnvironment = reader["RECOMMENDED_ENVIRONMENT"] == DBNull.Value ? "" : reader["RECOMMENDED_ENVIRONMENT"].ToString();
                        list.Add(dto);
                    }
                }
            }
            return list;
        }
    }
}