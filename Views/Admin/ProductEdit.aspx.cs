using ShoppingSite_a.Common;
using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;
using System;
using System.Web.UI;

namespace ShoppingSite_a.Views.Admin
{
    public partial class ProductEdit : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Validatorを正しく動かすためのおまじない
            this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            // 画面がボタンのクリック等ではなく、最初に開かれた時だけ実行する
            if (!IsPostBack)
            {
                // URLからパラメータ「productId」を取得する
                string reqParam = Request.QueryString["productId"];

                if (int.TryParse(reqParam, out int productId))
                {
                    //データベースから現在の商品の情報を1件取得
                    ProductDAO dao = new ProductDAO();
                    ProductDTO product = dao.GetById(productId);

                    if (product != null)
                    {
                        // 取得したデータを画面の各コントロールにセットする（詳細表示）
                        hfProductId.Value = product.ProductId.ToString(); // 隠しフィールドにIDを保持
                        txtProductName.Text = product.ProductName;
                        txtPrice.Text = product.Price.ToString();
                        txtStock.Text = product.Stock.ToString();
                        txtPlanet.Text = product.Planet;
                        txtDescription.Text = product.Description;

                        // ドロップダウンリストの選択状態を合わせる
                        ddlRecommendedEnvironment.SelectedValue = product.RecommendedEnvironment;
                        // ★追加：画像を表示し、現在のパスをHiddenFieldに保持
                        imgProduct.ImageUrl = ResolveUrl(product.ImagePath);
                        hfImagePath.Value = product.ImagePath;
                    }
                    else
                    {
                        lblMessage.Text = "対象の商品が見つかりませんでした。";
                        btnUpdate.Enabled = false; // ボタンを押せないようにする
                    }
                }
                else
                {
                    lblMessage.Text = "不正なアクセスです。商品IDが指定されていません。";
                    btnUpdate.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 「この内容で更新する」ボタンが押された時の処理
        /// </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // 1. バリデーション結果を確認 (Validatorが1つでもエラーならここで停止！)
            if (!Page.IsValid) return;

            try
            {   // ★追加：画像保存のロジック
                // デフォルトはHiddenFieldに入っている「現在の画像パス」
                string imagePathToSave = hfImagePath.Value;

                // 新しいファイルがアップロードされた場合のみ差し替える
                if (fuProductImage.HasFile)
                {
                    string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fuProductImage.FileName);
                    string savePath = Server.MapPath("~/Images/") + fileName;
                    fuProductImage.SaveAs(savePath);
                    imagePathToSave = "~/Images/" + fileName;
                }

                // 2. 隠しフィールドから保持しておいた商品IDを復元する
                int productId = Convert.ToInt32(hfProductId.Value);

                // 3. 画面の入力値を DTO オブジェクトに詰め替える
                // Validatorが数値であることを保証済みなので、安心して変換する
                ProductDTO product = new ProductDTO();
                product.ProductId = productId; // これがないと誰を更新していいかSQLが迷子になります
                product.ProductName = txtProductName.Text.Trim();
                product.Price = int.Parse(txtPrice.Text);
                product.Stock = int.Parse(txtStock.Text);
                product.Planet = txtPlanet.Text.Trim();
                product.Description = txtDescription.Text.Trim();
                product.RecommendedEnvironment = ddlRecommendedEnvironment.SelectedValue;
                // ★追加：画像パスをDTOにセット
                product.ImagePath = imagePathToSave;
                // 4. DAOを呼び出してデータベースを更新（UPDATE）する
                ProductDAO dao = new ProductDAO();
                dao.Update(product);

                // 5. 更新が成功したら、商品管理一覧画面へ戻る
                Response.Redirect("ProductManage.aspx");
            }
            catch (Exception ex)
            {
                // 万が一データベースエラーなどが起きた場合の対策
                lblMessage.Text = "更新中にエラーが発生しました: " + ex.Message;
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