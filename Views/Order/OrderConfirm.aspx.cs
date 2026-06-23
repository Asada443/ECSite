using System;
using System.Collections.Generic;
using ShoppingSite_a.Common;
using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;

namespace ShoppingSite_a.Views.Order
{
   
    public partial class OrderConfirm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // カート情報（List<CartItem>）を取得
                List<CartItem> cart = Session["Cart"] as List<CartItem>;

                if (cart == null || cart.Count == 0)
                {
                    // カートが空ならカート画面に戻す
                    Response.Redirect("~/Views/Cart/Cart.aspx");
                    return;
                }

                // 画面（Repeater）にカートの中身をバインド
                rptConfirm.DataSource = cart;
                rptConfirm.DataBind();

                // 合計金額と消費税の計算・表示
                int totalProductPrice = 0;
                foreach (var item in cart)
                {
                    totalProductPrice += item.SubTotal; // 各CartItemの小計を足していく
                }

                int tax = (int)(totalProductPrice * 0.1); // 消費税10%
                int grandTotal = totalProductPrice + tax;   // 税込合計金額

                lblTax.Text = tax.ToString("#,0");
                lblTotal.Text = grandTotal.ToString("#,0");
            }
        }

        /// <summary>
        /// 購入確定ボタンが押された時の処理
        /// </summary>
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            List<CartItem> cart = Session["Cart"] as List<CartItem>;
            if (cart == null || cart.Count == 0) return;

            // ==========================================================
            // [List<CartItem>] から [OrderDTO] への詰め替え
            // ==========================================================
            OrderDTO order = new OrderDTO();

            // BasePageからログイン中のユーザーID（MemberId）を取得してセット
            order.UserId = CurrentUser.UserId;

            int totalProductPrice = 0;

            // カートの商品を一品ずつ、Order明細DTOに詰め替える
            foreach (var cartItem in cart)
                totalProductPrice += cartItem.SubTotal;

            order.Tax = (int)(totalProductPrice * 0.1);
            order.TotalPrice = totalProductPrice + order.Tax;

            // 明細（Details）の詰め替え
            foreach (var cartItem in cart)
            {
                OrderDetailDTO detail = new OrderDetailDTO
                {
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    Price = cartItem.Price
                };
                order.Details.Add(detail);
            }

            // ==========================================================
            // DBへの登録処理
            // ==========================================================
            OrderDAO dao = new OrderDAO();
            int newOrderId = dao.InsertOrder(order); // 戻り値として新しい購入番号が返ってくる

            // カート内の商品情報を削除（クリア）する
            Session["Cart"] = null;

            // 購入処理完了後、購入完了画面へ遷移する（購入番号をオマケで渡す）
            Response.Redirect($"~/Views/Order/OrderComplete.aspx?OrderId={newOrderId}");
        }

        /// <summary>
        /// キャンセルボタンが押された時の処理
        /// </summary>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // 「キャンセル」ボタンを押下するとカート画面へ遷移する
            Response.Redirect("~/Views/Cart/Cart.aspx");
        }
    }
}