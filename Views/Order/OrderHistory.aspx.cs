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
    public partial class OrderHitory : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    // セッションからMemberDTOを取り出す
                    MemberDTO member = (MemberDTO)Session["User"];

                    // 【修正完了】会員DTOの中から、新しい宇宙会員ID（UserId）を取得する
                    string userId = member.UserId;

                    // DAOから履歴を取得してバインド
                    OrderDAO dao = new OrderDAO();

                    //  【修正完了】新しくなったDAOのメソッド「GetOrderHistoryByUserId」を呼び出す
                    List<OrderDTO> historyList = dao.GetOrderHistoryByUserId(userId);

                    rptOrderHistory.DataSource = historyList;
                    rptOrderHistory.DataBind();
                }
                else
                {
                    // セッションが無ければログイン画面へ
                    Response.Redirect("~/Views/Login/Login.aspx");
                }
            }
        }

        protected void rptOrderHistory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ShowDetail")
            {
                string orderId = e.CommandArgument.ToString();
                Response.Redirect("OrderHistoryDetail.aspx?orderId=" + orderId);
            }
        }

        protected void btnToTop_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Home/Top.aspx");
        }
    }
}