using System;
using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;

namespace ShoppingSite_a.Views.Order
{
    public partial class OrderComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // URLのパラメータから購入番号(OrderId)を取得
                string orderIdStr = Request.QueryString["OrderId"];

                if (!string.IsNullOrEmpty(orderIdStr))
                {
                    int orderId = int.Parse(orderIdStr);

                    // DAOを使って、今保存した注文データをDBからフレッシュに取得
                    OrderDAO dao = new OrderDAO();
                    OrderDTO order = dao.GetOrderCompleteData(orderId);

                    if (order != null)
                    {
                        // 画面の各項目にデータをセット
                        lblOrderId.Text = order.OrderId.ToString();
                        lblTax.Text = order.Tax.ToString("#,0");
                        lblTotal.Text = order.TotalPrice.ToString("#,0");

                        // 明細一覧を Repeater にバインド
                        rptDetails.DataSource = order.Details;
                        rptDetails.DataBind();
                    }
                }
            }
        }

        /// <summary>
        /// トップページへ戻るボタン
        /// </summary>
        protected void btnBackToTop_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home/Top.aspx"); 
        }

        /// <summary>
        /// 購入履歴を見るボタン 
        /// </summary>
        protected void btnHistory_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Views/Home/Top.aspx");
        }
    }
}