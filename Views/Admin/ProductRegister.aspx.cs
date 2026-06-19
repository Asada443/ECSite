using ShoppingSite_a.Common;
using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSite_a.Views.Admin
{
    public partial class ProductRegister :AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 「この内容で登録する」ボタンが押された時の処理
        /// </summary>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // 1. 入力チェック（バリデーション）
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                lblMessage.Text = "商品名を入力してください。";
                return;
            }

            if (!int.TryParse(txtPrice.Text, out int price) || price < 0)
            {
                lblMessage.Text = "価格には0以上の正しい数値を入力してください。";
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                lblMessage.Text = "在庫数には0以上の正しい数値を入力してください。";
                return;
            }

            try
            {
                // 2. 画面の入力値を DTO オブジェクトに詰め替える
                ProductDTO product = new ProductDTO();
                product.ProductName = txtProductName.Text.Trim();
                product.Price = price;
                product.Stock = stock;
                product.Planet = txtPlanet.Text.Trim();
                product.Description = txtDescription.Text.Trim();
                

                product.RecommendedEnvironment = ddlRecommendedEnvironment.SelectedValue;

                // 3. DAOを呼び出してデータベースに保存（INSERT）する
                ProductDAO dao = new ProductDAO();
                dao.Insert(product);

                // 4. 登録が成功したら、商品管理一覧画面（ProductManage.aspx）へ戻る
                Response.Redirect("ProductManage.aspx");
            }
            catch (Exception ex)
            {
                // 万が一データベースエラーなどが起きた場合の対策
                lblMessage.Text = "登録中にエラーが発生しました: " + ex.Message;
            }
        }

        /// <summary>
        /// 「商品管理一覧に戻る」ボタンが押された時の処理
        /// </summary>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            // 何もせず一覧画面にジャンプする
            Response.Redirect("ProductManage.aspx");
        }

    }
}