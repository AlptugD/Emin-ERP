using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ERP.UI
{
    public partial class FormAnaMenu : Form
    {
        private List<ProductItem> products = new List<ProductItem>();
        private string activeCategory = "Tümü";
        private List<Guna2Button> categoryButtons = new List<Guna2Button>();

        public FormAnaMenu()
        {
            InitializeComponent();
            this.FormClosed += (s, ev) => Application.Exit();
        }

        private void FormAnaMenu_Load(object sender, EventArgs e)
        {
            InitializeProducts();
            CreateCategoryButtons();
            RenderProducts();
        }

        private void InitializeProducts()
        {
            products.Add(new ProductItem
            {
                Name = "Mavi Premium Kulaklık",
                Brand = "ProComputer",
                Price = 125.00,
                Category = "Telefon Aksesuarları",
                ImageFileName = "blue_headphones.png",
                PrimaryColor = Color.CornflowerBlue
            });

            products.Add(new ProductItem
            {
                Name = "Oyun Konsolu Kolu",
                Brand = "PlayStation",
                Price = 97.00,
                Category = "Masaüstü Bilgisayarlar",
                ImageFileName = "white_controller.png",
                PrimaryColor = Color.LightGray
            });

            products.Add(new ProductItem
            {
                Name = "Çiçek Desenli Tablet Kılıfı",
                Brand = "TabletArt",
                Price = 89.00,
                Category = "Kılıflar & Ekran Koruyucular",
                ImageFileName = "tablet_case.png",
                PrimaryColor = Color.Plum
            });

            products.Add(new ProductItem
            {
                Name = "Lavanta Rengi Kulaklık",
                Brand = "Emin Store",
                Price = 77.00,
                Category = "Kablosuz Kulaklıklar",
                ImageFileName = "lavender_headphones.png",
                PrimaryColor = Color.MediumPurple
            });

            products.Add(new ProductItem
            {
                Name = "Mor Akıllı Telefon",
                Brand = "BrandX",
                Price = 699.00,
                Category = "Telefon Aksesuarları",
                ImageFileName = "purple_smartphone.png",
                PrimaryColor = Color.Purple
            });

            products.Add(new ProductItem
            {
                Name = "Dizüstü Oyuncu Bilgisayarı",
                Brand = "MSI's Brand",
                Price = 999.00,
                Category = "Dizüstü Bilgisayarlar",
                ImageFileName = "gaming_laptop.png",
                PrimaryColor = Color.SlateGray
            });
        }

        private void CreateCategoryButtons()
        {
            string[] categories = {
                "Tümü",
                "Telefon Aksesuarları",
                "Kılıflar & Ekran Koruyucular",
                "Şarj Cihazları",
                "Kablosuz Kulaklıklar",
                "Akıllı Saatler",
                "Dizüstü Bilgisayarlar",
                "Masaüstü Bilgisayarlar"
            };

            int startY = 10;
            foreach (string cat in categories)
            {
                Guna2Button btn = new Guna2Button();
                btn.Text = cat + "  >";
                btn.TextAlign = HorizontalAlignment.Left;
                btn.FillColor = Color.Transparent;
                btn.ForeColor = cat == activeCategory ? Color.FromArgb(142, 68, 173) : Color.FromArgb(80, 80, 80);
                btn.Font = new Font("Segoe UI", cat == activeCategory ? 9.5f : 9.0f, cat == activeCategory ? FontStyle.Bold : FontStyle.Regular);
                btn.Size = new Size(240, 32);
                btn.Location = new Point(5, startY);
                btn.Cursor = Cursors.Hand;
                btn.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                btn.Click += (s, ev) => {
                    activeCategory = cat;
                    UpdateCategoryButtonStyles();
                    ApplyFilters();
                };

                pnlCategories.Controls.Add(btn);
                categoryButtons.Add(btn);
                startY += 36;
            }
        }

        private void UpdateCategoryButtonStyles()
        {
            foreach (var btn in categoryButtons)
            {
                string catName = btn.Text.Replace("  >", "").Trim();
                if (catName == activeCategory)
                {
                    btn.ForeColor = Color.FromArgb(142, 68, 173);
                    btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                }
                else
                {
                    btn.ForeColor = Color.FromArgb(80, 80, 80);
                    btn.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular);
                }
            }
        }

        private void RenderProducts()
        {
            flowLayoutProducts.Controls.Clear();
            flowLayoutProducts.AutoScroll = true;

            foreach (var item in products)
            {
                // Create Card Panel
                Guna2Panel card = new Guna2Panel();
                card.Size = new Size(310, 350);
                card.BorderColor = Color.FromArgb(240, 240, 240);
                card.BorderThickness = 1;
                card.BorderRadius = 15;
                card.FillColor = Color.White;
                card.Margin = new Padding(10);
                card.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();

                // Image PictureBox
                Guna2PictureBox pb = new Guna2PictureBox();
                pb.Size = new Size(290, 220);
                pb.Location = new Point(10, 10);
                pb.BorderRadius = 12;
                pb.Image = GetProductImage(item.ImageFileName, item.Name, item.PrimaryColor);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                card.Controls.Add(pb);

                // Heart / Favorite Button
                Guna2Button btnFav = new Guna2Button();
                btnFav.Size = new Size(32, 32);
                btnFav.Location = new Point(255, 20);
                btnFav.BorderRadius = 16;
                btnFav.FillColor = Color.FromArgb(200, 255, 255, 255);
                btnFav.Text = "🤍";
                btnFav.ForeColor = Color.Red;
                btnFav.Font = new Font("Segoe UI", 10);
                btnFav.Cursor = Cursors.Hand;
                btnFav.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                bool isFav = false;
                btnFav.Click += (s, ev) => {
                    isFav = !isFav;
                    btnFav.Text = isFav ? "❤️" : "🤍";
                };
                card.Controls.Add(btnFav);

                // Product Title
                Label lblTitle = new Label();
                lblTitle.Text = item.Name;
                lblTitle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                lblTitle.Location = new Point(15, 245);
                lblTitle.Size = new Size(180, 45);
                lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
                card.Controls.Add(lblTitle);

                // Seller / Brand
                Label lblBrand = new Label();
                lblBrand.Text = item.Brand;
                lblBrand.Font = new Font("Segoe UI", 8.0f);
                lblBrand.Location = new Point(15, 295);
                lblBrand.Size = new Size(150, 20);
                lblBrand.ForeColor = Color.DarkGray;
                card.Controls.Add(lblBrand);

                // Price Tag
                Guna2Button btnPrice = new Guna2Button();
                btnPrice.Text = "₺" + item.Price.ToString("F2");
                btnPrice.Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold);
                btnPrice.FillColor = Color.FromArgb(245, 245, 245);
                btnPrice.ForeColor = Color.Black;
                btnPrice.BorderRadius = 10;
                btnPrice.Size = new Size(95, 30);
                btnPrice.Location = new Point(200, 290);
                btnPrice.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                card.Controls.Add(btnPrice);

                flowLayoutProducts.Controls.Add(card);
                item.CardPanel = card;
            }
        }

        private Image GetProductImage(string fileName, string productName, Color primaryColor)
        {
            string path = Path.Combine(Application.StartupPath, "Resources", fileName);
            if (File.Exists(path))
            {
                try
                {
                    return Image.FromFile(path);
                }
                catch { }
            }

            // Fallback drawing using Graphics
            Bitmap bmp = new Bitmap(290, 220);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(248, 249, 250));
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Simple soft circle
                using (Brush b = new SolidBrush(Color.FromArgb(40, primaryColor)))
                {
                    g.FillEllipse(b, 85, 40, 120, 120);
                }

                // Stylized outline icon based on product type
                using (Pen p = new Pen(primaryColor, 5))
                {
                    if (productName.Contains("Kulaklık"))
                    {
                        g.DrawArc(p, 105, 60, 80, 80, 180, 180);
                        g.FillEllipse(new SolidBrush(primaryColor), 95, 95, 20, 35);
                        g.FillEllipse(new SolidBrush(primaryColor), 175, 95, 20, 35);
                    }
                    else if (productName.Contains("Konsol") || productName.Contains("Kolu"))
                    {
                        g.DrawArc(p, 105, 75, 80, 50, 180, 180);
                        g.DrawLine(p, 105, 100, 185, 100);
                        g.FillEllipse(new SolidBrush(primaryColor), 115, 85, 12, 12);
                        g.FillEllipse(new SolidBrush(primaryColor), 163, 85, 12, 12);
                    }
                    else if (productName.Contains("Kılıf"))
                    {
                        g.DrawRectangle(p, 110, 55, 70, 95);
                        g.FillRectangle(new SolidBrush(primaryColor), 120, 65, 50, 75);
                    }
                    else if (productName.Contains("Telefon"))
                    {
                        g.DrawRectangle(p, 115, 50, 60, 110);
                        g.FillEllipse(new SolidBrush(primaryColor), 142, 145, 8, 8);
                    }
                    else if (productName.Contains("Bilgisayar"))
                    {
                        g.DrawRectangle(p, 100, 60, 90, 60);
                        g.DrawLine(p, 85, 120, 205, 120);
                    }
                }
            }
            return bmp;
        }

        private void ApplyFilters()
        {
            double min = 0;
            double max = 999999;
            double.TryParse(txtMinPrice.Text, out min);
            double.TryParse(txtMaxPrice.Text, out max);
            string search = txtSearch.Text.Trim().ToLower();

            foreach (var item in products)
            {
                bool matchesCategory = (activeCategory == "Tümü" || item.Category == activeCategory);
                bool matchesPrice = (item.Price >= min && item.Price <= max);
                bool matchesSearch = string.IsNullOrEmpty(search) || 
                                     item.Name.ToLower().Contains(search) || 
                                     item.Brand.ToLower().Contains(search);

                if (item.CardPanel != null)
                {
                    item.CardPanel.Visible = matchesCategory && matchesPrice && matchesSearch;
                }
            }
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnDahaFazlaGor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblSeoDescription.Text = "Teknoloji Ürünleri – Türkiye'de online teknoloji alışverişi yapmak için en iyi web sitesini mi arıyorsunuz? O halde, yenilikçi ve güçlü teknolojik cihazlar için arayışınız burada sona eriyor. Günlük kullanıma uygun pratik akıllı cihazlardan, üst düzey performans sunan premium donanımlara kadar Emin Ticaret, en güncel ve en iyi teknoloji koleksiyonunu tek bir çatı altında sunuyor. Geniş teknoloji ürünleri yelpazemiz, seçimlerinizle dijital dünyada fark yaratmanızı ve her zaman bir adım önde olmanızı sağlayacak.\n\n" +
                                     "Tüm Teknoloji İhtiyaçlarınız İçin Tek Adres: Emin Ticaret\n\n" +
                                     "Günümüzde teknoloji, hayatımızın her alanında her zamankinden daha fazla yer kaplıyor. Artık yavaş ve kullanışsız cihazlarla vakit kaybettiğimiz günler geride kaldı. Bugün, hayatı kolaylaştıran akıllı donanımlar ve ergonomik tasarımlar, verimliliği ve konforu zirveye taşıyor. Bu doğrultuda Emin Ticaret, sizi işinizde, oyununuzda ve günlük yaşantınızda her zaman kazanan yapacak geniş bir premium teknoloji yelpazesine sahip.\n\n" +
                                     "Teknoloji koleksiyonumuz, dijital yaşam tarzınızda ikonik bir kalite standardı belirlemenizi sağlayacak. Şunu açıkça söyleyebiliriz ki; her zaman aradığınız o üstün donanım gücünü ve şık tasarımı bir arada sunan güvenilir teknoloji mağazalarının sayısı oldukça azdır. Emin ERP olarak biz, ürün yönetimini ve tedariğini sizler için en kolay ve şeffaf hale getirmek için buradayız.";

            // Expand heights to fit the full text
            pnlSeoSection.Height = 450;
            pnlContent.Height = 1580;
            btnDahaFazlaGor.Visible = false;
        }
    }

    public class ProductItem
    {
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Category { get; set; } = string.Empty;
        public string ImageFileName { get; set; } = string.Empty;
        public Color PrimaryColor { get; set; }
        public Guna2Panel? CardPanel { get; set; }
    }
}
