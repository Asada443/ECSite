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
            // Validatorを正しく動かすためのおまじない
            this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // 1.  バリデーション結果を確認 (Validatorが1つでもエラーならここで停止！)
            if (!Page.IsValid) return;

            try
            {
                // 2. 画面の入力値を DTO オブジェクトに詰め替える
                // Validatorが「数値であること」を保証済みなので、int.Parseで安全に変換できる
                ProductDTO product = new ProductDTO();
                product.ProductName = txtProductName.Text.Trim();
                product.Price = int.Parse(txtPrice.Text);
                product.Stock = int.Parse(txtStock.Text);
                product.Planet = txtPlanet.Text.Trim();
                product.Description = txtDescription.Text.Trim();
                product.RecommendedEnvironment = ddlRecommendedEnvironment.SelectedValue;

                // 3. DAOを呼び出してデータベースに保存
                ProductDAO dao = new ProductDAO();
                dao.Insert(product);

                // 4. 成功したら一覧へ
                Response.Redirect("ProductManage.aspx");
            }
            catch (Exception ex)
            {
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