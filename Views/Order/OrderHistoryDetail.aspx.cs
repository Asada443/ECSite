using ShoppingSite_a.Common;
using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSite_a.Views.Order
{
    public partial class OrderHistoryDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // URLの「?orderId=xxx」の部分を取得する
                string reqOrderId = Request.QueryString["orderId"];

                // 安全チェック：パラメータが存在し、かつ数値に変換できる場合のみ処理
                if (!string.IsNullOrEmpty(reqOrderId) && int.TryParse(reqOrderId, out int orderId))
                {
                    // 昨日作ったDAOのメソッドを呼び出す
                    OrderDAO dao = new OrderDAO();
                    OrderDTO orderDto = dao.GetOrderCompleteData(orderId);

                    if (orderDto != null)
                    {
                        // ① 親情報のバインド（ラベルへセット）
                        lblOrderId.Text = orderDto.OrderId.ToString();
                        lblCreatedAt.Text = orderDto.CreatedAt.ToString("yyyy/MM/dd HH:mm");
                        lblTax.Text = orderDto.Tax.ToString("N0");
                        lblTotalPrice.Text = orderDto.TotalPrice.ToString("N0");
                        lblTotalPrice.Text = orderDto.TotalPrice.ToString("N0");

                        // ② 明細情報のバインド（Repeaterへセット）
                        rptOrderDetails.DataSource = orderDto.Details;
                        rptOrderDetails.DataBind();
                    }
                    else
                    {
                        // 該当する注文データがなかった場合
                        Response.Redirect("/Views/Order/OrderHistory.aspx");
                    }
                }
                else
                {
                    // 不正なパラメータでアクセスされた場合は履歴一覧に戻す
                    Response.Redirect("/Views/Oreder/OrderHistory.aspx");
                }
            }
        }

        /// <summary>
        /// 購入履歴へ戻るボタン
        /// </summary>
        protected void btnToHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Views/Order/OrderHistory.aspx");
        }

        /// <summary>
        /// トップページへ戻るボタン
        /// </summary>
        protected void btnToTop_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Views/Home/Top.aspx");
        }
    }
}