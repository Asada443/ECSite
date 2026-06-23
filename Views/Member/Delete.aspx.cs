using ShoppingSite_a.Common;
using ShoppingSite_a.DAO;
using System;

namespace ShoppingSite_a.Member
{
    public partial class Delete : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ログインしていない不審なアクセスを弾く（BasePage側の仕組みと連動）
            if (CurrentUser == null)
            {
                Response.Redirect("~/Views/Login/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                
                lblUserId.Text = CurrentUser.UserId;
                lblUserName.Text = CurrentUser.UserName;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            MemberDAO dao = new MemberDAO();

            // DBからデリート
            dao.Delete(CurrentUser.UserId);

            // 削除されたので、ログインセッションを消す
            Session.Remove("User");

            // 削除完了画面へ
            Response.Redirect("~/Views/Member/DeleteComplete.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Views/Member/Home.aspx");
        }
    }
}