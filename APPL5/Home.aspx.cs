
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

    namespace APPL5
    {
        public class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public double Price { get; set; }
            public string Image { get; set; }
            public int Quantity { get; set; }

        }
    }

    public partial class home : System.Web.UI.Page
    {
        private static List<Product> products = new List<Product>
        {
            new Product { ID = 1, Name = "Chitarra", Description = "Fender Stratocaster", Price = 599.99, Image = "https://sc1.musik-produktiv.com/pic-010144418l/fender-custom-shop-limited-edition-1956-stratocaster-10144418.jpg" },
            new Product { ID = 2, Name = "Basso", Description = "Fender Jazzmaster", Price = 378.99, Image = "https://rvb-img.reverb.com/image/upload/s--S49F6DIM--/f_auto,t_large/v1588708715/jkpc4orvi4usraetgvcw.jpg" },
            new Product { ID = 3, Name = "Batteria", Description = "Pearl", Price = 1213.99, Image = "https://www.guitarsland.it/pub/media/catalog/product/cache/cf3f2243ef4940fd5c66f2ff035145ac/m/a/masv529xpc_1.jpg" },
            new Product { ID = 4, Name = "Cuffie", Description = "Presonus", Price = 100.00, Image = "https://www.promusicbari.it/products_images/normal/5835486105bc215e350915.png" },
            new Product { ID = 5, Name = "Saxophone", Description = "Saxx", Price = 877.00, Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4b/Yamaha_Saxophone_YAS-62.tif/lossy-page1-800px-Yamaha_Saxophone_YAS-62.tif.jpg" },
            new Product { ID = 6, Name = "Mixer", Description = "Miles", Price = 129.99, Image = "https://cittadellamusica.store/media/catalog/product/cache/57968b0aced5afe6e25f313ef6bea898/l/i/live-x16-mixer-professionale-15-ch-mono-1-stereo_63ca93dacc7e8.jpg" },

        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptProducts.DataSource = products;
                rptProducts.DataBind();
            }
        }

        protected void ViewDetails_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productId = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect($"Details.aspx?ID={productId}");
        }

        protected void ViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        public static Product GetProductById(int productId)
        {
            return products.FirstOrDefault(p => p.ID == productId);
        }

    }


