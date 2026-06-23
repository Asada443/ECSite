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
            // 変数名を memberId から userId に統一！
            string userId = txtMemberId.Text;
            string password = txtPassword.Text;

            // --- 入力チェック ---
            if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(password))
            {
                lblError.Text = "会員IDとパスワードを入力してください";
                return;
            }
            if (string.IsNullOrEmpty(userId))
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
            
            MemberDTO member = dao.Login(userId, password);

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
                    //  支配者（ROLE）によって遷移先を切り替える判定
                    if (member.Role == "Admin")
                    {
                        // 
                        Response.Redirect("~/Views/Member/Home.aspx");
                    }
                    else
                    {
                        // 一般ユーザーの場合は、新しく決めたトップページ（Top.aspx）へ
                        Response.Redirect("~/Views/Home/Top.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("~/Views/Login/Error.aspx");
            }
        }
    }
}