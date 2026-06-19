using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSite_a.Views.Home
{
    public partial class Top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // セッションからログイン情報を取得（MemberDTOに型変換）
                MemberDTO loginUser = Session["User"] as MemberDTO;
                ProductDAO productDao = new ProductDAO();
                List<ProductDTO> productList = null;


                if (loginUser != null)
                {
                    //ログイン中の場合
                    pnlGuestHeader.Visible = false;   // ログインボタンを隠す
                    pnlMemberHeader.Visible = true;   // 会員用メニューを出す

                    // 「ようこそ、〇〇さん！」の文字を設定
                    lblWelcome.Text = $"ようこそ、{loginUser.LastName} {loginUser.FirstName} さん！";

                    // おすすめ商品の抽出
                    lblListTitle.Text = "あなたの好みにピッタリの移住先（おすすめ）";

                    // ユーザーの好みの環境（"都市型"など）を使って検索
                    productList = productDao.GetRecommendedProducts(loginUser.PreferredEnvironment);

                    if (productList == null || productList.Count == 0)
                    {
                        lblNoProductsMessage.Text = "おすすめの商品はありません。";
                        lblNoProductsMessage.Visible = true;
                    }
                }
                else
                {
                    //未ログイン（ゲスト）の場合
                    pnlGuestHeader.Visible = true;    // ログインボタンを出す
                    pnlMemberHeader.Visible = false;  // 会員用メニューを隠す

                    lblListTitle.Text = "大人気！売れ筋の移住枠（残りわずか）";
                    productList = productDao.GetPopularProducts();

                    if (productList == null || productList.Count == 0)
                    {
                        lblNoProductsMessage.Text = "商品が登録されていません。";
                        lblNoProductsMessage.Visible = true;
                    }
                }
                // リピーターにデータを詰め込んで画面に表示させる！
                if (productList != null && productList.Count > 0)
                {
                    lblNoProductsMessage.Visible = false;
                    rptProducts.DataSource = productList;
                    rptProducts.DataBind();
                }
            }
        }

        protected void btnProductList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Product/ProductList.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text;
            Response.Redirect("~/Views/Product/ProductList.aspx?keyword=" + HttpUtility.UrlEncode(keyword));
        }

        /// <summary>
        /// 「ログイン」ボタンが押された時の処理
        /// </summary>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Login/Login.aspx"); 
        }

        /// <summary>
        /// 「マイページ」ボタンが押された時の処理
        /// </summary>
        protected void btnMyPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Home.aspx");
        }

        /// <summary>
        /// 「ログアウト」ボタンが押された時の処理
        /// </summary>
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // セッションをクリアして、自分自身（Top.aspx）にリダイレクト
            Session.Remove("User");
            Response.Redirect("~/Views/Home/Top.aspx");
        }
    }
}