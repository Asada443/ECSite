using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingSite_a.Common
{
    public class AdminBasePage:BasePage
    {
        protected override void OnLoad(EventArgs e)
        {
            //未ログインチェック
            base.OnLoad(e);

            //Adminじゃなければマイページへ弾く
            if (CurrentUser != null && CurrentUser.Role != "Admin")
            {
                Response.Redirect("~/Views/Member/Home.aspx");
            }

        }
    }
}