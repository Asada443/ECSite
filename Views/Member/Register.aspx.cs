using ShoppingSite_a.Common;
using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShoppingSite_a.Member
{
    public partial class Register : System.Web.UI.Page
    {
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            // エラーメッセージ初期化
            lblError.Text = "";

            // =========================
            // ■ 会員IDチェック
            // =========================

            // 未入力チェック
            if (string.IsNullOrEmpty(txtMemberId.Text))
            {
                lblError.Text = "会員IDを入力してください";
                return;
            }

            // =========================
            // ■ パスワードチェック
            // =========================

            // 未入力チェック
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lblError.Text = "パスワードを入力してください";
                return;
            }

            // 文字数チェック（8～32文字）
            if (txtPassword.Text.Length < 8 ||
                txtPassword.Text.Length > 32)
            {
                lblError.Text = "パスワードは8～32文字で入力してください";
                return;
            }

            // 使用できる文字チェック（英数字＋記号のみ）
            if (!System.Text.RegularExpressions.Regex.IsMatch(
                txtPassword.Text,
                @"^[a-zA-Z0-9!-/:-@[-`{-~]+$"))
            {
                lblError.Text = "パスワードに使用できない文字が含まれています";
                return;
            }

            // 英字が1文字以上含まれているか
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPassword.Text, "[a-zA-Z]"))
            {
                lblError.Text = "パスワードは英字を含めてください";
                return;
            }

            // 数字が1文字以上含まれているか
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPassword.Text, "[0-9]"))
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

            // 未入力チェック
            if (string.IsNullOrEmpty(txtMailAddress.Text))
            {
                lblError.Text = "メールアドレスを入力してください";
                return;
            }

            // 文字数チェック（最大254文字）
            if (txtMailAddress.Text.Length > 254)
            {
                lblError.Text = "メールアドレスは254文字以内で入力してください";
                return;
            }

            // @の数チェック（必ず1個）
            if (txtMailAddress.Text.Count(c => c == '@') != 1)
            {
                lblError.Text = "メールアドレスの形式が正しくありません";
                return;
            }

            // @の位置チェック（先頭・末尾NG）
            int atIndex = txtMailAddress.Text.IndexOf('@');

            if (atIndex <= 0 || atIndex >= txtMailAddress.Text.Length - 1)
            {
                lblError.Text = "メールアドレスの形式が正しくありません";
                return;
            }

            // ドメイン部分取得（@以降）
            string[] parts = txtMailAddress.Text.Split('@');
            string domain = parts[1];

            // ドメインに「.」が含まれているか
            if (!domain.Contains("."))
            {
                lblError.Text = "メールアドレスの形式が正しくありません";
                return;
            }

            // 故郷の星は任意なのでチェック不要

            // 好みの環境
            if (string.IsNullOrEmpty(ddlPreferredEnvironment.SelectedValue))
            {
                lblError.Text = "好みの環境を選択してください";
                return;
            }

            // =========================
            // ■ 会員ID重複チェック（DB）
            // =========================

            MemberDAO dao = new MemberDAO();

            if (dao.Exists(txtMemberId.Text))
            {
                lblError.Text = "この会員IDは既に使用されています";
                return;
            }

            // =========================
            // ■ 登録データ作成
            // =========================

            MemberDTO member = new MemberDTO();

            member.MemberId = txtMemberId.Text;
            member.Password = txtPassword.Text;
            member.LastName = txtLastName.Text;
            member.FirstName = txtFirstName.Text;
            member.Address = txtAddress.Text;
            member.MailAddress = txtMailAddress.Text;

            member.HomePlanet = txtHomePlanet.Text;
            member.PreferredEnvironment = ddlPreferredEnvironment.SelectedValue;

            member.Role = "User";

            // 一時保存（確認画面へ渡す）
            Session["TempRegister"] = member;

            // 確認画面へ遷移
            Response.Redirect("~/Views/Member/Confirm.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            // ログイン画面へ遷移
            Response.Redirect("~/Views/Login/Login.aspx");
        }
    }
}