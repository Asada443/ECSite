using ShoppingSite_a.Common;
using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;
using System;
using System.Web.UI;

namespace ShoppingSite_a
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            string userId = txtMemberId.Text;
            string password = txtPassword.Text;

            if (password.Length < 8 || password.Length > 32)
            {
                lblError.Text = "パスワードは8文字以上32文字以下で入力してください";
                return;
            }

            MemberDAO dao = new MemberDAO();
            MemberDTO member = dao.Login(userId, password);

            if (member != null)
            {
                Session["User"] = member;
                // ログイン成功時の遷移処理
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    Response.Redirect(returnUrl);
                }
                else
                {
                    Response.Redirect(member.Role == "Admin" ? "~/Views/Member/Home.aspx" : "~/Views/Home/Top.aspx");
                }
            }
            else
            {
                // 遷移をやめて、その場でメッセージを表示
                lblError.Text = "会員IDまたはパスワードが正しくありません。";
            }
        }
    }
}