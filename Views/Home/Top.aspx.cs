using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSite_a.Views.Home
{
    public partial class Top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProductList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Product/ProductList.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text;

            Response.Redirect(
                "~/Views/Product/ProductList.aspx?keyword=" + keyword);
        }
    }
}