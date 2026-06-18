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
            string memberId = txtMemberId.Text;
            string password = txtPassword.Text;

            // --- 入力チェック ---
            if (string.IsNullOrEmpty(memberId) && string.IsNullOrEmpty(password))
            {
                lblError.Text = "会員IDとパスワードを入力してください";
                return;
            }
            if (string.IsNullOrEmpty(memberId))
            {
                lblError.Text = "会員IDを入力してください";
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                lblError.Text = "パスワードを入力してください";
                return;
            }
            if (password.Length < 8 || password.Length > 32)
            {
                lblError.Text = "パスワードは8文字以上32文字以下で入力してください";
                return;
            }

            // --- 認証処理 ---
            MemberDAO dao = new MemberDAO();
            MemberDTO member = dao.Login(memberId, password);

            if (member != null)
            {
                Session["User"] = member;

                
                string returnUrl = null;
                foreach (string key in Request.QueryString.AllKeys)
                {
                    if (key != null && key.Equals("ReturnUrl", StringComparison.OrdinalIgnoreCase))
                    {
                        returnUrl = Request.QueryString[key];
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    /* カートから来た場合は、ここ（購入確認画面）にジャンプ */
                    Response.Redirect(returnUrl);
                }
                else
                {
                    // 普通にログインした場合はマイページへ
                    Response.Redirect("~/Views/Member/Home.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Views/Login/Error.aspx");
            }
        }
    }
}