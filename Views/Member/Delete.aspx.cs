using ShoppingSite_a.Common;
using ShoppingSite_a.DAO;
using System;

namespace ShoppingSite_a.Member
{
    public partial class Delete : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMemberId.Text = CurrentUser.MemberId;
                lblLastName.Text = CurrentUser.LastName;
                lblFirstName.Text = CurrentUser.FirstName;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            MemberDAO dao = new MemberDAO();

            dao.Delete(CurrentUser.MemberId);

            Session.Remove("User");

            Response.Redirect("~/Views/Member/DeleteComplete.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Home.aspx");
        }
    }
}