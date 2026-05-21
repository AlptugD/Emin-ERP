using System.Collections.Generic;
using System.Drawing;

namespace ERP.UI
{
    public static class ProductCatalog
    {
        private static List<ProductItem>? _products;

        public static List<ProductItem> Products
        {
            get
            {
                if (_products == null)
                    _products = CreateProducts();
                return _products;
            }
        }

        private static List<ProductItem> CreateProducts()
        {
            return new List<ProductItem>
            {
                new ProductItem
                {
                    Name = "Mavi Premium Kablosuz Kulaklık",
                    Brand = "ProCompute",
                    Price = 3499.00,
                    Category = "Kablosuz Kulaklıklar",
                    ImageFileName = "blue_headphones.png",
                    PrimaryColor = Color.FromArgb(94, 145, 196),
                    Stock = 10
                },
                new ProductItem
                {
                    Name = "Taşınabilir Oyun Konsolu",
                    Brand = "PlayAnywhere",
                    Price = 12999.00,
                    Category = "Masaüstü Bilgisayarlar",
                    ImageFileName = "white_controller.png",
                    PrimaryColor = Color.FromArgb(220, 224, 230),
                    Stock = 5
                },
                new ProductItem
                {
                    Name = "Çiçek Desenli Tablet Kılıfı",
                    Brand = "SkinArt",
                    Price = 699.00,
                    Category = "Kılıflar & Ekran Koruyucular",
                    ImageFileName = "tablet_case.png",
                    PrimaryColor = Color.FromArgb(240, 215, 215),
                    Stock = 0
                },
                new ProductItem
                {
                    Name = "Lavanta Rengi Kablosuz Kulaklık",
                    Brand = "SonicWave",
                    Price = 1999.00,
                    Category = "Kablosuz Kulaklıklar",
                    ImageFileName = "lavender_headphones.png",
                    PrimaryColor = Color.FromArgb(215, 200, 235),
                    Stock = 8
                },
                new ProductItem
                {
                    Name = "White Graphic Crop Top",
                    Brand = "woden's Brand",
                    Price = 449.00,
                    Category = "Telefon Aksesuarları",
                    ImageFileName = "white_crop_top.png",
                    PrimaryColor = Color.FromArgb(235, 230, 240),
                    Stock = 0
                },
                new ProductItem
                {
                    Name = "Black Shorts",
                    Brand = "MM's Brand",
                    Price = 549.00,
                    Category = "Dizüstü Bilgisayarlar",
                    ImageFileName = "black_shorts.png",
                    PrimaryColor = Color.FromArgb(230, 230, 230),
                    Stock = 15
                }
            };
        }
    }
}
