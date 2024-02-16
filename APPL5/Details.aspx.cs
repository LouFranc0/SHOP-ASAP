using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace APPL5
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.QueryString["ID"], out int productId))
                {
                    Product product = GetProductById(productId);

                    if (product != null)
                    {
                        lblProductName.Text = $" {product.Name}";
                        lblProductDescription.Text = $" {product.Description}";
                        lblProductPrice.Text = $" ${product.Price:F2}";
                        imgProduct.ImageUrl = product.Image;
                    }
                    else
                    {
                        Response.Redirect("ErrorPage.aspx");
                    }
                }
                else
                {
                    Response.Redirect("ErrorPage.aspx");
                }
            }
        }

        protected void AddToCart_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Request.QueryString["ID"], out int productId))
            {
                Product selectedProduct = GetProductById(productId);
                if (selectedProduct != null)
                {
                    AddProductToCart(selectedProduct);
                }
            }
        }

        private void AddProductToCart(Product product)
        {
            List<Product> cartItems = GetCartItems();
            Product existingProduct = cartItems.FirstOrDefault(p => p.ID == product.ID);

            if (existingProduct != null)
            {
                existingProduct.Quantity += 1;
            }
            else
            {
                product.Quantity = 1;
                cartItems.Add(product);
            }

            SetCartItems(cartItems);
        }


        private Product GetProductById(int productId)
        {
            return home.GetProductById(productId);
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

        protected void ViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void ViewHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}
