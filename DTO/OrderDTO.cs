using System;
using System.Collections.Generic;

namespace ShoppingSite_a.DTO
{
    // ① 注文の親情報（T_ORDERテーブルに対応）
    public class OrderDTO
    {
        public int OrderId { get; set; }        // 購入番号 (ORDER_ID)

        
        public string UserId { get; set; }      // 会員ID (USER_ID)

        public int TotalPrice { get; set; }     // 合計金額 (TOTAL_PRICE)
        public int Tax { get; set; }            // 消費税 (TAX)
        public DateTime CreatedAt { get; set; } // 購入日時 (CREATED_AT)

        // この注文に紐づく商品の明細リスト（複数持てるようにする）
        public List<OrderDetailDTO> Details { get; set; } = new List<OrderDetailDTO>();
    }

    // ② 注文の明細情報（T_ORDER_DETAILテーブルに対応）
    public class OrderDetailDTO
    {
        public int OrderDetailId { get; set; }   // 明細ID (ORDER_DETAIL_ID)
        public int OrderId { get; set; }         // 購入番号 (ORDER_ID)
        public int ProductId { get; set; }       // 商品ID (PRODUCT_ID)
        public string ProductName { get; set; }  // 商品名（★画面表示のために追加）
        public int Quantity { get; set; }        // 数量 (QUANTITY)
        public int Price { get; set; }           // 購入時の単価 (PRICE)

        // 小計を自動計算するプロパティ（単価 × 数量）
        public int SubTotal
        {
            get { return Price * Quantity; }
        }
    }
}