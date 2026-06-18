using ShoppingSite_a.Common;
using ShoppingSite_a.DTO;
using System;
using System.Linq;
using System.Text.RegularExpressions;
namespace ShoppingSite_a.Member
{
    public partial class Edit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtMemberId.Text = CurrentUser.MemberId;
                txtPassword.Text = CurrentUser.Password;
                txtLastName.Text = CurrentUser.LastName;
                txtFirstName.Text = CurrentUser.FirstName;
                txtAddress.Text = CurrentUser.Address;
                txtMailAddress.Text = CurrentUser.MailAddress;
                txtHomePlanet.Text = CurrentUser.HomePlanet;
                ddlPreferredEnvironment.SelectedValue = CurrentUser.PreferredEnvironment;

            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            // =========================
            // ■ パスワードチェック
            // =========================

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lblError.Text = "パスワードを入力してください";
                return;
            }

            if (txtPassword.Text.Length < 8 ||
                txtPassword.Text.Length > 32)
            {
                lblError.Text = "パスワードは8～32文字で入力してください";
                return;
            }

            // 使用可能文字チェック
            if (!Regex.IsMatch(
                txtPassword.Text,
                @"^[a-zA-Z0-9!-/:-@[-`{-~]+$"))
            {
                lblError.Text = "パスワードに使用できない文字が含まれています";
                return;
            }

            // 英字必須
            if (!Regex.IsMatch(txtPassword.Text, "[a-zA-Z]"))
            {
                lblError.Text = "パスワードは英字を含めてください";
                return;
            }

            // 数字必須
            if (!Regex.IsMatch(txtPassword.Text, "[0-9]"))
            {
                lblError.Text = "パスワードは数字を含めてください";
                return;
            }

            // =========================
            // ■ 氏名チェック
            // =========================

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                lblError.Text = "姓を入力してください";
                return;
            }

            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                lblError.Text = "名を入力してください";
                return;
            }

            // =========================
            // ■ 住所チェック
            // =========================

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                lblError.Text = "住所を入力してください";
                return;
            }

            // =========================
            // ■ メールアドレスチェック
            // =========================

            if (string.IsNullOrEmpty(txtMailAddress.Text))
            {
                lblError.Text = "メールアドレスを入力してください";
                return;
            }

            if (txtMailAddress.Text.Length > 254)
            {
                lblError.Text = "メールアドレスは254文字以内で入力してください";
                return;
            }

            if (txtMailAddress.Text.Count(c => c == '@') != 1)
            {
                lblError.Text = "メールアドレスの形式が正しくありません";
                return;
            }

            int atIndex = txtMailAddress.Text.IndexOf('@');

            if (atIndex <= 0 || atIndex >= txtMailAddress.Text.Length - 1)
            {
                lblError.Text = "メールアドレスの形式が正しくありません";
                return;
            }

            string[] parts = txtMailAddress.Text.Split('@');
            string domain = parts[1];

            if (!domain.Contains("."))
            {
                lblError.Text = "メールアドレスの形式が正しくありません";
                return;
            }

            if (string.IsNullOrEmpty(ddlPreferredEnvironment.SelectedValue))
            {
                lblError.Text = "好みの環境を選択してください";
                return;
            }

            MemberDTO member = new MemberDTO();

            member.MemberId = txtMemberId.Text;
            member.Password = txtPassword.Text;
            member.LastName = txtLastName.Text;
            member.FirstName = txtFirstName.Text;
            member.Address = txtAddress.Text;
            member.MailAddress = txtMailAddress.Text;
            member.HomePlanet = txtHomePlanet.Text;
            member.PreferredEnvironment = ddlPreferredEnvironment.SelectedValue;

            member.Role = CurrentUser.Role;  /*Update後もUser→Userを維持するため*/

            Session["TempEdit"] = member;

            Response.Redirect("~/Views/Member/EditConfirm.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Home.aspx");
        }
    }
}