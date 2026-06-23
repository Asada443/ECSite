using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace ShoppingSite_a.Views.Home
{
    public partial class Top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 商品表示のためのDAOだけあればいいの
                ProductDAO productDao = new ProductDAO();
                MemberDTO loginUser = Session["User"] as MemberDTO;
                List<ProductDTO> productList = null;

                if (loginUser != null)
                {
                    // ログイン時の商品抽出
                    lblListTitle.Text = "あなたの好みにピッタリの移住先（おすすめ）";
                    productList = productDao.GetRecommendedProducts(loginUser.RecommendedEnvironment);
                }
                else
                {
                    // 未ログイン時の商品抽出
                    lblListTitle.Text = "大人気！売れ筋の移住枠（残りわずか）";
                    productList = productDao.GetPopularProducts();
                }

                // データバインド
                if (productList != null && productList.Count > 0)
                {
                    rptProducts.DataSource = productList;
                    rptProducts.DataBind();
                }
                else
                {
                    lblNoProductsMessage.Text = "商品が登録されていません。";
                    lblNoProductsMessage.Visible = true;
                }
            }
        }
    }
}