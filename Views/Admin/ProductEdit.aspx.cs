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
            // 1. 入力チェック（バリデーション）※新規登録と同じチェック
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
                // 2. 隠しフィールドから保持しておいた商品IDを復元する
                int productId = Convert.ToInt32(hfProductId.Value);

                // 3. 画面の入力値を DTO オブジェクトに詰め替える
                ProductDTO product = new ProductDTO();
                product.ProductId = productId; // これがないと誰を更新していいかSQLが迷子になります
                product.ProductName = txtProductName.Text.Trim();
                product.Price = price;
                product.Stock = stock;
                product.Planet = txtPlanet.Text.Trim();
                product.Description = txtDescription.Text.Trim();
                product.RecommendedEnvironment = ddlRecommendedEnvironment.SelectedValue;

                // 4. DAOを呼び出してデータベースを更新（UPDATE）する
                ProductDAO dao = new ProductDAO();
                dao.Update(product);

                // 5. 更新が成功したら、商品管理一覧画面へ戻る
                Response.Redirect("ProductManage.aspx");
            }
            catch (Exception ex)
            {
                lblMessage.Text = "更新中にエラーが発生しました: " + ex.Message;
            }
        }

        /// <summary>
        /// 「商品管理一覧に戻る」ボタンが押された時の処理
        /// </summary>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductManage.aspx");
        }
    }
}