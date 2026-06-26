using ShoppingSite_a.Common;
using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;
using System;
using System.Web.UI;

namespace ShoppingSite_a.Member
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // もしValidatorでエラーが出たらこの1行で回避するおまじない
            this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            // 画面側のバリデーションがOKか確認
            if (!Page.IsValid) return;

            // 唯一サーバーでしか確認できない重複チェック
            MemberDAO dao = new MemberDAO();
            if (dao.Exists(txtUserId.Text))
            {
                lblError.Text = "この会員IDは既に使用されています";
                return;
            }

            // セッションに保存して画面遷移
            MemberDTO member = new MemberDTO();
            member.UserId = txtUserId.Text;
            member.Password = txtPassword.Text;
            member.UserName = txtUserName.Text;
            member.HometownPlanet = txtHometownPlanet.Text;
            member.RecommendedEnvironment = ddlRecommendedEnvironment.SelectedValue;
            member.Role = "User";

            Session["TempRegister"] = member;
            Response.Redirect("~/Views/Member/Confirm.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Login/Login.aspx");
        }
    }
}