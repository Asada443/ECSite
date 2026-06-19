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
    public partial class ProductManage : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // 画面が開かれたときに商品一覧をバインド
                BindProductList();
            }
        }

        /// <summary>
        /// 商品一覧を取得してRepeaterに表示するメソッド
        /// </summary>
        private void BindProductList()
        {
            ProductDAO dao = new ProductDAO();

            // DAOにある「GetAll()」を呼び出す
            List<ProductDTO> productList = dao.GetAll();

            rptProducts.DataSource = productList;
            rptProducts.DataBind();
        }

        /// <summary>
        /// Repeaterの中のボタン（編集・削除）が押された時の処理
        /// </summary>
        /// 
        protected void rptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            // コマンド引数から商品IDを取得
            int productId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditProduct")
            {
                // 編集ボタン：編集画面（ProductEdit.aspx）へ商品IDを渡して遷移
                Response.Redirect($"ProductEdit.aspx?productId={productId}");
            }
            else if (e.CommandName == "DeleteProduct")
            {
                try
                {
                    // 【実装完了】削除用のDAOを呼び出してDBから削除
                    ProductDAO dao = new ProductDAO();
                    dao.Delete(productId);

                    // 再読み込みして一覧を更新
                    BindProductList();
                }
                catch (Exception ex)
                {
                   lblMessage.Text = "削除中にエラーが発生しました"+ex.Message;
                }
            }
        }

        /// <summary>
        /// 新規登録ボタンが押された時の処理
        /// </summary>
        protected void btnNewProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductRegister.aspx");
        }

        /// <summary>
        /// 一般ユーザー用トップ画面へ戻るボタン
        /// </summary>
        protected void btnBackToTop_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Home.aspx");

        }
    }
}