using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_a.DTO
{
    [Serializable]
    public class CartItem
    {
        // 商品ID（どの商品か識別）
        public int ProductId { get; set; }

        // 商品名（画面表示用）
        public string ProductName { get; set; }

        // 価格（単価）
        public int Price { get; set; }

        // 数量（ユーザーが決める）
        public int Quantity { get; set; }

        // 在庫（移住枠制限用）
        public int Stock { get; set; }

        // 画像パス（カート画面で表示）
        public string ImagePath { get; set; }

        // 小計（計算プロパティ）
        public int SubTotal
        {
            get { return Price * Quantity; }
        }
    }
}