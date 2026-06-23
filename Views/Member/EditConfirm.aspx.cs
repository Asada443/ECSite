using ShoppingSite_a.Common;
using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;
using System;

namespace ShoppingSite_a.Member
{
    public partial class EditConfirm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 不正アクセス防止（修正用の一時セッションがなければ入力画面へ強制送還）
            if (Session["TempEdit"] == null)
            {
                Response.Redirect("~/Views/Member/Edit.aspx");
                return;
            }

            if (!IsPostBack)
            {
                MemberDTO member = Session["TempEdit"] as MemberDTO;

                
                lblUserId.Text = member.UserId;
                lblUserName.Text = member.UserName;
                lblHometownPlanet.Text = member.HometownPlanet;
                lblRecommendedEnvironment.Text = member.RecommendedEnvironment;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // ボタンクリック時もセッションのダブルチェック
            if (Session["TempEdit"] == null)
            {
                Response.Redirect("~/Views/Member/Edit.aspx");
                return;
            }

            MemberDTO member = Session["TempEdit"] as MemberDTO;

            // MemberDAOを呼び出して、UPDATE
            MemberDAO dao = new MemberDAO();
            dao.Update(member);

            // ログイン中セッション（CurrentUserの中身）を、今DBに書き込んだ最新情報で上書き
            Session["User"] = dao.GetMember(member.UserId);

            // 修正用の一時セッションはお掃除
            Session.Remove("TempEdit");

            // 修正完了画面へ
            Response.Redirect("~/Views/Member/EditComplete.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            // 入力画面へ戻る
            Response.Redirect("~/Views/Member/Edit.aspx");
        }
    }
}

