using ShoppingSite_a.Common;
using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;
using System;

namespace ShoppingSite_a.Member
{
    public partial class Confirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 不正アクセス防止（セッションが空っぽなら登録画面へ強制送還）
            if (Session["TempRegister"] == null)
            {
                Response.Redirect("~/Views/Member/Register.aspx");
                return;
            }

            if (!IsPostBack)
            {
                MemberDTO member = Session["TempRegister"] as MemberDTO;

                // 新しいラベルID ＆ 新しいDTOプロパティ名に書き換え
                lblUserId.Text = member.UserId;
                lblUserName.Text = member.UserName;
                lblHometownPlanet.Text = member.HometownPlanet;
                lblRecommendedEnvironment.Text = member.RecommendedEnvironment;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // ダブルチェック（登録ボタンを押したときもセッションを確認）
            if (Session["TempRegister"] == null)
            {
                Response.Redirect("~/Views/Member/Register.aspx");
                return;
            }

            MemberDTO member = Session["TempRegister"] as MemberDTO;
            if (member == null)
            {
                Response.Redirect("~/Views/Member/Register.aspx");
                return;
            }

            // データベース（DAO）へインサート
            MemberDAO dao = new MemberDAO();
            dao.Insert(member);

            // 登録が終わったので、セッションの宇宙船はお掃除
            Session.Remove("TempRegister");

            // 完了画面（Complete.aspx）へ
            Response.Redirect("~/Views/Member/Complete.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            // 「修正する」で登録画面に戻る
            Response.Redirect("~/Views/Member/Register.aspx");
        }
    }
}