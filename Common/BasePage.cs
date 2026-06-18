using ShoppingSite_a.DTO;
using System;
using System.Web;
using System.Web.UI;

namespace ShoppingSite_a.Common
{
    public class BasePage : Page
    {
        protected MemberDTO CurrentUser
        {
            get { return Session["User"] as MemberDTO; }
        }

        protected override void OnLoad(EventArgs e)
        {
            if (CurrentUser == null)
            {
                /* 今アクセスしようとしたページのURL */
                string currentUrl = Request.RawUrl;

              
                string loginUrl = ResolveUrl("~/Views/Login/Login.aspx");

         
                Response.Redirect($"{loginUrl}?ReturnUrl={HttpUtility.UrlEncode(currentUrl)}", true);
                return;
            }

            base.OnLoad(e);
        }
    }
}