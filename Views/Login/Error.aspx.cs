using ShoppingSite_a.Common;
using System;

namespace ShoppingSite_a
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Login/Login.aspx");
        }
    }
}