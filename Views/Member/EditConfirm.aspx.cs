using ShoppingSite_a.Common;
using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSite_a.Member
{
    public partial class EditConfirm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TempEdit"] == null)
            {
                Response.Redirect("~/Views/Member/Edit.aspx");
                return;
            }

            if (!IsPostBack)
            {
                MemberDTO member = Session["TempEdit"] as MemberDTO;

                lblMemberId.Text = member.MemberId;
                lblLastName.Text = member.LastName;
                lblFirstName.Text = member.FirstName;
                lblAddress.Text = member.Address;
                lblMailAddress.Text = member.MailAddress;
                lblHomePlanet.Text = member.HomePlanet;
                lblPreferredEnvironment.Text = member.PreferredEnvironment;
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["TempEdit"] == null)
            {
                Response.Redirect("~/Views/Member/Edit.aspx");
                return;
            }

            MemberDTO member = Session["TempEdit"] as MemberDTO;

            MemberDAO dao = new MemberDAO();
            dao.Update(member);

            Session["User"] = dao.GetMember(member.MemberId);
            Session.Remove("TempEdit");


            Response.Redirect("~/Views/Member/EditComplete.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Edit.aspx");
        }
    }
}
    
