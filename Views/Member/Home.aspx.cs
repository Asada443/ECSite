using ShoppingSite_a.Common;
using ShoppingSite_a.DTO;
using System;
using System.Web;
using System.Web.UI;

namespace ShoppingSite_a
{
    public partial class Home : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // セッションからログインユーザー情報を取得
                MemberDTO loginUser = Session["User"] as MemberDTO;

                if (loginUser == null)
                {
                    // ログインしていなければログイン画面へ強制送還
                    Response.Redirect("~/Views/Login/Login.aspx");
                    return;
                }

                // 【修正完了】新ラベル「lblUserName」に「UserName」を表示！
                lblUserName.Text = loginUser.UserName;

               
                if (loginUser.Role == "Admin")
                {
                    btnProductManage.Visible = true;
                    btnHistory.Visible = false;
                }
                else
                {
                    btnProductManage.Visible = false;
                    btnHistory.Visible= true;
                }
        }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Edit.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Delete.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Response.Redirect("~/Views/Home/Top.aspx");
        }

        protected void btnProductManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/ProductManage.aspx");
        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Order/OrderHistory.aspx");
        }
    }
}