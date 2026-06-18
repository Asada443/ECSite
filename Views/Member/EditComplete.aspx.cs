using ShoppingSite_a.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSite_a.Member
{
    public partial class EditComplete : BasePage

    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Home.aspx");
        }

    }
}