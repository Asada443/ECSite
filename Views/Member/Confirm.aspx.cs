using ShoppingSite_a.Common;
using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;
using System;


namespace ShoppingSite_a.Member
{
    public partial class Confirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["TempRegister"] == null)
            {
                Response.Redirect("~/Views/Member/Register.aspx");
                return;
            }

            if (!IsPostBack)
            {
                MemberDTO member = Session["TempRegister"] as MemberDTO;

                lblMemberId.Text = member.MemberId;
                lblLastName.Text = member.LastName;
                lblFirstName.Text = member.FirstName;
                lblAddress.Text = member.Address;
                lblMailAddress.Text = member.MailAddress;
                lblHomePlanet.Text = member.HomePlanet;
                lblPreferredEnvironment.Text = member.PreferredEnvironment;
            }
        }
        

        
           protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Session["TempRegister"] == null)
            {
                Response.Redirect("~/Views/Member/Register.aspx");
                return;
            }

            MemberDTO member = Session["TempRegister"] as MemberDTO;
            if (member == null)
            {
                Response.Redirect("~/Views/Member/Register.aspx");
                return;
            }

            MemberDAO dao = new MemberDAO();
            dao.Insert(member);

            Session.Remove("TempRegister");

            Response.Redirect("~/Views/Member/Complete.aspx");
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Member/Register.aspx");
        }
    }
}