using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ShoppingSite_a.Product
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string keyword = Request.QueryString["keyword"];

                if (!string.IsNullOrEmpty(keyword))
                {
                    ProductDAO dao = new ProductDAO();

                    List<ProductDTO> list = dao.Search(keyword);

                    rptProducts.DataSource = list;
                    rptProducts.DataBind();

                    lblCount.Text = $"検索結果：{list.Count}件";

                    if (list.Count == 0)
                    {
                        lblError.Text = "該当する移住先がありません";
                    }
                    else
                    {
                        lblError.Text = "";
                    }
                }
                else
                {
                    LoadProducts("NEW");
                }
            }
        }
        protected void btnSort_Click(object sender, EventArgs e)
        {
            string keyword = Request.QueryString["keyword"];

            if (!string.IsNullOrEmpty(keyword))
            {
                ProductDAO dao = new ProductDAO();

                rptProducts.DataSource =
                    dao.Search(keyword, ddlSort.SelectedValue);

                rptProducts.DataBind();
            }
            else
            {
                LoadProducts(ddlSort.SelectedValue);
            }
        }

        private void LoadProducts(string sortType)
        {
            ProductDAO dao = new ProductDAO();


            rptProducts.DataSource = dao.GetAll(sortType);
            rptProducts.DataBind();
        }

        protected void rptProducts_ItemCommand(
    object source,
    RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Detail")
            {
                Response.Redirect(
                    "~/Views/Product/ProductDetail.aspx?id="
                    + e.CommandArgument);
            }
        }
    }
}