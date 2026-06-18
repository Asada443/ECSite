using ShoppingSite_a.DAO;
using ShoppingSite_a.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingSite_a.Views.Product
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["id"], out int id))
            {
                Response.Redirect("~/Views/Product/ProductList.aspx");
                return;
            }

            
            ProductDAO dao = new ProductDAO();
            ProductDTO p = dao.GetById(id);

            if (p == null)
            {
                Response.Redirect("~/Views/Product/ProductList.aspx");
                return;
            }

            lblProductName.Text = p.ProductName;
            lblPrice.Text = p.Price.ToString();
            lblPlanet.Text = p.Planet;
            lblStock.Text = p.Stock.ToString();
            lblDescription.Text = p.Description;
            lblRecommendedEnvironment.Text = p.RecommendedEnvironment;
            imgProduct.ImageUrl = p.ImagePath;

            if (!IsPostBack)            /* 在庫数だけ選択肢を表示*/
            {
                ddlQty.Items.Clear();

                for (int i = 1; i <= p.Stock; i++)      
                {
                    ddlQty.Items.Add(i.ToString());
                }
            }
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            int qty =int.Parse(ddlQty.SelectedValue);/*ddで選んだ値を取得*/

            int productId;

           if(!int.TryParse( Request.QueryString["id"], out productId ))   
            {
                return;                                  
            }

            ProductDAO dao = new ProductDAO();           
            ProductDTO p = dao.GetById(productId);/*DBから商品情報取得*/

            if (p == null)
            {
                return;
            }

            if (qty > p.Stock)
            {
                lblMessage.Text = "在庫数を超えています";
                return;
            }


            List<CartItem> cart = Session["Cart"] as List<CartItem>;

            if (cart == null)
            {
                cart = new List<CartItem>();
                Session["Cart"] = cart;
            }

            CartItem item = cart.Find(x => x.ProductId == productId);

            if (item == null)
            {
                CartItem newItem = new CartItem();

                newItem.ProductId = p.ProductId;
                newItem.ProductName = p.ProductName;
                newItem.Price = p.Price;
                newItem.Stock = p.Stock;
                newItem.ImagePath = p.ImagePath;
                newItem.Quantity = qty;

                cart.Add(newItem);
                lblMessage.Text = "カートに追加しました";
            }
            else
            {
                int newQty = item.Quantity + qty;

                if (newQty > p.Stock)
                {
                    item.Quantity = p.Stock;
                    lblMessage.Text = "在庫数を超えるため最大数まで追加しました";
                }
                else
                {
                    item.Quantity = newQty;
                    lblMessage.Text = "カートに追加しました";
                }
            }


        }
            
         

        protected void btnGoCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Cart/Cart.aspx");
        }
    }

}