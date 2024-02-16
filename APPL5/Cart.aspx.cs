using APPL5.APPL5;
using APPL5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace lezione60z
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

        protected void RemoveFromCart_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productId = Convert.ToInt32(btn.CommandArgument);

            List<Product> cartItems = GetCartItems();
            Product productToRemove = cartItems.FirstOrDefault(p => p.ID == productId);
            if (productToRemove != null)
            {
                cartItems.Remove(productToRemove);
                SetCartItems(cartItems);
                BindCart();
            }
        }

        protected void ClearCart_Click(object sender, EventArgs e)
        {
            SetCartItems(new List<Product>());
            BindCart();
        }

        private void BindCart()
        {
            List<Product> cartItems = GetCartItems();

            var groupedItems = cartItems
                .GroupBy(p => p.ID)
                .Select(group => new Product
                {
                    ID = group.Key,
                    Name = group.First().Name,
                    Description = group.First().Description,
                    Price = group.First().Price,
                    Image = group.First().Image,
                    Quantity = group.Sum(item => item.Quantity)
                })
                .ToList();

            rptCart.DataSource = groupedItems;
            rptCart.DataBind();

            double total = groupedItems.Sum(p => p.Price * p.Quantity);
            lblTotal.Text = total.ToString("F2");
        }


        private List<Product> GetCartItems()
        {
            if (Session["CartItems"] == null)
                Session["CartItems"] = new List<Product>();
            return (List<Product>)Session["CartItems"];
        }

        private void SetCartItems(List<Product> cartItems)
        {
            Session["CartItems"] = cartItems;
        }

        protected void ViewHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

    }
}
