using ShoppingSite_a.Common;
using ShoppingSite_a.DTO;
using System;

namespace ShoppingSite_a
{
    public partial class Home : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                lblLastName.Text = CurrentUser.LastName;
                if (CurrentUser.Role == "Admin")
                {
                    btnProductManage.Visible = true;
                }

            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Edit.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Delete.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Views/Member/LogoutConfirm.aspx");
        }

        protected void btnProductManage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Admin/ProductManage.aspx");
        }

    }
}