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
            // 1. バリデーション結果を確認
            if (!Page.IsValid) return;

            try
            {
                // 画像が選択されているかチェック
                if (fuProductImage.HasFile)
                {
                    // 2. ファイル名をユニークにする（Guidを使って重複を防ぐ）
                    string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fuProductImage.FileName);

                    // 3. サーバー内の物理的な保存先パスを作成
                    string savePath = Server.MapPath("~/Images/") + fileName;

                    // 4. 保存実行
                    fuProductImage.SaveAs(savePath);

                    // 5. DBに保存するパス（~/Images/ファイル名）を作成
                    string dbPath = "~/Images/" + fileName;

                    // 6. 画面の入力値を DTO オブジェクトに詰め替える
                    ProductDTO product = new ProductDTO();
                    product.ProductName = txtProductName.Text.Trim();
                    product.Price = int.Parse(txtPrice.Text);
                    product.Stock = int.Parse(txtStock.Text);
                    product.Planet = txtPlanet.Text.Trim();
                    product.Description = txtDescription.Text.Trim();
                    product.RecommendedEnvironment = ddlRecommendedEnvironment.SelectedValue;
                    product.ImagePath = dbPath; // ★重要：ここでパスをセット

                    // 7. DAOを呼び出してデータベースに保存
                    ProductDAO dao = new ProductDAO();
                    dao.Insert(product);

                    // 8. 成功したら一覧へ
                    Response.Redirect("ProductManage.aspx");
                }
                else
                {
                    lblMessage.Text = "商品画像を選択してください。";
                }
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