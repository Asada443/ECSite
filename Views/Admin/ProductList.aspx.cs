using ShoppingSite_a.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSite_a.Admin
{
    public partial class ProductList : BasePage

    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(CurrentUser.Role != "Admin")
            {
                Response.Redirect("~/Views/Member/Home.aspx");
            }

        }
    }
}