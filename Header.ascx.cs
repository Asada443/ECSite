using ShoppingSite_a.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSite_a
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MemberDTO loginUser = Session["User"] as MemberDTO;
                if (loginUser != null)
                {
                    // ログイン中の表示
                    pnlGuestHeader.Visible = false;
                    pnlMemberHeader.Visible = true;
                    lblWelcome.Text = $"ようこそ、{loginUser.UserName} さん！";
                }
                else
                {
                    // 未ログインの表示
                    pnlGuestHeader.Visible = true;
                    pnlMemberHeader.Visible = false;
                }
            }
        }

        // ヘッダーに関係あるボタン機能だけ書く
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Product/ProductList.aspx?keyword=" + Server.UrlEncode(txtKeyword.Text));
        }

        protected void btnProductList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Product/ProductList.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Login/Login.aspx");
        }

        protected void btnMyPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Home.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Response.Redirect("~/Views/Home/Top.aspx");
        }
    }
}