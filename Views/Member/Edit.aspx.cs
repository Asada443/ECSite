using ShoppingSite_a.Common;
using ShoppingSite_a.DTO;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace ShoppingSite_a.Member
{
    public partial class Edit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // バリデーションエラー時の動作を安定させるおまじない
            this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (CurrentUser == null)
            {
                Response.Redirect("~/Views/Login/Login.aspx");
                return;
            }

            // 鉄則：最初の一回だけDBからデータを読み込む！
            // これでバリデーションで弾かれて再表示されても値が消えない！
            if (!IsPostBack)
            {
                txtUserId.Text = CurrentUser.UserId;
                txtPassword.Text = CurrentUser.Password;
                txtUserName.Text = CurrentUser.UserName;
                txtHometownPlanet.Text = CurrentUser.HometownPlanet;
                ddlRecommendedEnvironment.SelectedValue = CurrentUser.RecommendedEnvironment;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            // これがフロント側(Validator)の全チェック結果を受け取る魔法の1行！
            if (!Page.IsValid) return;

            // バリデーションが通ったら、データの詰め替えと遷移
            MemberDTO member = new MemberDTO();
            member.UserId = txtUserId.Text;
            member.Password = txtPassword.Text;
            member.UserName = txtUserName.Text;
            member.HometownPlanet = txtHometownPlanet.Text;
            member.RecommendedEnvironment = ddlRecommendedEnvironment.SelectedValue;
            member.Role = CurrentUser.Role;

            // 確認画面への引き渡し
            Session["TempEdit"] = member;
            Response.Redirect("~/Views/Member/EditConfirm.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Home.aspx");
        }
    }
}