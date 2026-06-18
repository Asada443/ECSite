using ShoppingSite_a.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSite_a.Views.Cart
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCart();
            }
        }

        private void BindCart()/*表示担当*//*セッションからカートを取り出して画面に表示*/
        {
            List<CartItem> cart =
                Session["Cart"] as List<CartItem>;

            if (cart == null || cart.Count == 0)
            {
                lblMessage.Text = "カートは空です";
                rptCart.DataSource = null;
                rptCart.DataBind();

                lblTotal.Text = "0";
                return;
            }

            lblMessage.Text = "";
            rptCart.DataSource = cart;/*cartの中身をHTMLに変換して表示*/
            rptCart.DataBind();

            lblTotal.Text = cart.Sum(x => x.SubTotal).ToString();/*全商品の合計*/
        }


        protected void rptCart_ItemDataBound(object sender, RepeaterItemEventArgs e)/*商品ごとに数量リストを作る処理*/
        {
            if (e.Item.ItemType != ListItemType.Item &&
                e.Item.ItemType != ListItemType.AlternatingItem)
                return;

            CartItem item = (CartItem)e.Item.DataItem;

            DropDownList ddl =
                (DropDownList)e.Item.FindControl("ddlQty");

            ddl.Items.Clear();

            for (int i = 1; i <= item.Stock; i++)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            ddl.SelectedValue = item.Quantity.ToString();
        }


        protected void rptCart_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int productId =
                    int.Parse(e.CommandArgument.ToString());

                List<CartItem> cart =
                    Session["Cart"] as List<CartItem>;

                CartItem item =
                    cart.Find(x => x.ProductId == productId);

                if (item != null)
                {
                    cart.Remove(item);
                }

                Session["Cart"] = cart;

                BindCart();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            List<CartItem> cart =
                Session["Cart"] as List<CartItem>;

            if (cart == null) return;

            foreach (RepeaterItem item in rptCart.Items)
            {
                HiddenField hf =
                    (HiddenField)item.FindControl("hfProductId");

                DropDownList ddl =
                    (DropDownList)item.FindControl("ddlQty");

                int productId = int.Parse(hf.Value);
                int newQty = int.Parse(ddl.SelectedValue);

                CartItem cartItem =
                    cart.Find(x => x.ProductId == productId);

                if (cartItem != null)
                {
                    cartItem.Quantity = newQty;
                }
            }

            Session["Cart"] = cart;

            BindCart();
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            List<CartItem> cart =
                Session["Cart"] as List<CartItem>;

            if (cart == null || cart.Count == 0)
            {
                lblMessage.Text = "カートが空です";
                return;
            }

            Response.Redirect("~/Views/Order/OrderConfirm.aspx");
        }


    }


}