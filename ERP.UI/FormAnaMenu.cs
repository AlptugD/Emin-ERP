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
        public bool ExitOnClose { get; set; } = true;

        public FormAnaMenu()
        {
            InitializeComponent();
            this.FormClosed += (s, ev) => { if (ExitOnClose) Application.Exit(); };
            btnCart.Click += btnCart_Click;
            CartManager.CartChanged += UpdateCartBadge;
        }

        private void FormAnaMenu_Load(object sender, EventArgs e)
        {
            products = ProductCatalog.Products;
            CreateCategoryButtons();
            RenderProducts();
            UpdateCartBadge();

            if (tbPrice != null)
                tbPrice.Value = 15000;

            if (AppSession.IsAdmin)
            {
                Guna2Button btnAdminPanel = new Guna2Button();
                btnAdminPanel.Text = "🔧 Admin Paneli";
                btnAdminPanel.Font = new Font("Segoe UI Semibold", 9f, FontStyle.Bold);
                btnAdminPanel.FillColor = Color.FromArgb(22, 22, 40);
                btnAdminPanel.ForeColor = Color.White;
                btnAdminPanel.BorderRadius = 8;
                btnAdminPanel.Size = new Size(148, 32);
                btnAdminPanel.Location = new Point(this.ClientSize.Width - 168, 10);
                btnAdminPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                btnAdminPanel.Cursor = Cursors.Hand;
                btnAdminPanel.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                btnAdminPanel.Click += (s, ev) =>
                {
                    FormAdminStok adminForm = new FormAdminStok();
                    adminForm.FormClosed -= null;
                    adminForm.FormClosed += (sa, eva) => Application.Exit();
                    adminForm.Show();
                    this.Hide();
                };
                this.Controls.Add(btnAdminPanel);
                btnAdminPanel.BringToFront();
            }
        }

        private void CreateCategoryButtons()
        {
            string[] categories = {
                "Telefon Aksesuarları",
                "Kılıflar & Ekran Koruyucular",
                "Şarj Cihazları",
                "Kablosuz Kulaklıklar",
                "Akıllı Saatler",
                "Dizüstü Bilgisayarlar",
                "Masaüstü Bilgisayarlar"
            };

            int startY = 10;
            pnlCategories.Controls.Clear();
            categoryButtons.Clear();

            foreach (string cat in categories)
            {
                Guna2Button btn = new Guna2Button();
                btn.Text = cat;
                btn.TextAlign = HorizontalAlignment.Left;
                btn.FillColor = Color.Transparent;
                btn.ForeColor = cat == activeCategory ? Color.FromArgb(142, 68, 173) : Color.FromArgb(120, 120, 120);
                btn.Font = new Font("Segoe UI Semibold", cat == activeCategory ? 9.5f : 9.0f, cat == activeCategory ? FontStyle.Bold : FontStyle.Regular);
                btn.Size = new Size(240, 32);
                btn.Location = new Point(0, startY);
                btn.Cursor = Cursors.Hand;
                btn.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                btn.HoverState.ForeColor = Color.FromArgb(142, 68, 173);
                btn.HoverState.FillColor = Color.FromArgb(250, 245, 255);

                Label lblArrow = new Label();
                lblArrow.Text = ">";
                lblArrow.ForeColor = Color.FromArgb(180, 180, 180);
                lblArrow.Font = new Font("Segoe UI Semibold", 9.0f, FontStyle.Bold);
                lblArrow.Size = new Size(15, 20);
                lblArrow.Location = new Point(220, 6);
                lblArrow.BackColor = Color.Transparent;
                lblArrow.Cursor = Cursors.Hand;
                btn.Controls.Add(lblArrow);

                btn.Click += (s, ev) =>
                {
                    activeCategory = (activeCategory == cat) ? "Tümü" : cat;
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
                if (btn.Text == activeCategory)
                {
                    btn.ForeColor = Color.FromArgb(142, 68, 173);
                    btn.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                }
                else
                {
                    btn.ForeColor = Color.FromArgb(120, 120, 120);
                    btn.Font = new Font("Segoe UI Semibold", 9.0f, FontStyle.Regular);
                }
            }
        }

        private void RenderProducts()
        {
            flowLayoutProducts.Controls.Clear();
            flowLayoutProducts.AutoScroll = false;

            foreach (var item in products)
            {
                if (!AppSession.IsAdmin && item.Stock <= 0)
                    continue;

                Guna2Panel card = new Guna2Panel();
                card.Size = new Size(310, 360);
                card.BorderColor = Color.FromArgb(242, 242, 242);
                card.BorderThickness = 1;
                card.BorderRadius = 16;
                card.FillColor = Color.White;
                card.Margin = new Padding(10);
                card.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();

                Guna2PictureBox pb = new Guna2PictureBox();
                pb.Size = new Size(290, 230);
                pb.Location = new Point(10, 10);
                pb.BorderRadius = 12;
                pb.Image = GetProductImage(item.ImageFileName, item.Name, item.PrimaryColor);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                card.Controls.Add(pb);

                Guna2Button btnFav = new Guna2Button();
                btnFav.Size = new Size(36, 36);
                btnFav.Location = new Point(250, 20);
                btnFav.BorderRadius = 18;
                btnFav.FillColor = Color.White;
                btnFav.Text = "🤍";
                btnFav.ForeColor = Color.FromArgb(120, 120, 120);
                btnFav.Font = new Font("Segoe UI", 10.5f);
                btnFav.Cursor = Cursors.Hand;
                btnFav.ShadowDecoration.Enabled = true;
                btnFav.ShadowDecoration.Shadow = new Padding(1, 1, 3, 3);
                btnFav.ShadowDecoration.Depth = 10;
                btnFav.ShadowDecoration.BorderRadius = 18;
                btnFav.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();

                bool isFav = false;
                btnFav.Click += (s, ev) =>
                {
                    isFav = !isFav;
                    btnFav.Text = isFav ? "❤️" : "🤍";
                    btnFav.ForeColor = isFav ? Color.Red : Color.FromArgb(120, 120, 120);
                };
                card.Controls.Add(btnFav);

                Label lblTitle = new Label();
                lblTitle.Text = item.Name;
                lblTitle.Font = new Font("Segoe UI Semibold", 10.0f, FontStyle.Bold);
                lblTitle.Location = new Point(15, 245);
                lblTitle.Size = new Size(280, 38);
                lblTitle.ForeColor = Color.FromArgb(40, 40, 40);
                card.Controls.Add(lblTitle);

                Label lblBrand = new Label();
                lblBrand.Text = item.Brand;
                lblBrand.Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Regular);
                lblBrand.Location = new Point(15, 293);
                lblBrand.Size = new Size(170, 18);
                lblBrand.ForeColor = Color.FromArgb(160, 160, 160);
                card.Controls.Add(lblBrand);

                Guna2Button btnPrice = new Guna2Button();
                btnPrice.Text = item.Price.ToString("N2") + " TL";
                btnPrice.Font = new Font("Segoe UI Semibold", 9.0f, FontStyle.Bold);
                btnPrice.FillColor = Color.FromArgb(245, 245, 245);
                btnPrice.ForeColor = Color.FromArgb(40, 40, 40);
                btnPrice.BorderRadius = 12;
                btnPrice.Size = new Size(95, 28);
                btnPrice.Location = new Point(200, 288);
                btnPrice.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                card.Controls.Add(btnPrice);

                if (AppSession.IsAdmin)
                {
                    Label lblStock = new Label();
                    lblStock.Text = $"Stok: {item.Stock}";
                    lblStock.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold);
                    lblStock.Location = new Point(15, 324);
                    lblStock.Size = new Size(80, 20);
                    lblStock.ForeColor = item.Stock > 0 ? Color.FromArgb(28, 160, 105) : Color.FromArgb(200, 50, 50);
                    card.Controls.Add(lblStock);
                }
                else
                {
                    Guna2Button btnAddToCart = new Guna2Button();
                    btnAddToCart.Text = "+ Ekle";
                    btnAddToCart.Font = new Font("Segoe UI Semibold", 8.5f, FontStyle.Bold);
                    btnAddToCart.FillColor = Color.FromArgb(33, 150, 243);
                    btnAddToCart.ForeColor = Color.White;
                    btnAddToCart.BorderRadius = 10;
                    btnAddToCart.Size = new Size(95, 28);
                    btnAddToCart.Location = new Point(200, 320);
                    btnAddToCart.Cursor = Cursors.Hand;
                    btnAddToCart.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                    btnAddToCart.Click += (s, ev) =>
                    {
                        bool isSuccess = CartManager.Add(item);

                        if (!isSuccess)
                        {
                            MessageBox.Show($"Bu üründen stokta en fazla {item.Stock} adet bulunmaktadır!", "Yetersiz Stok", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string originalText = btnAddToCart.Text;
                        Color originalColor = btnAddToCart.FillColor;

                        btnAddToCart.Text = "✓ Eklendi";
                        btnAddToCart.FillColor = Color.FromArgb(46, 204, 113);
                        btnAddToCart.Enabled = false;

                        System.Windows.Forms.Timer resetTimer = new System.Windows.Forms.Timer();
                        resetTimer.Interval = 1200;
                        resetTimer.Tick += (senderTimer, eTimer) =>
                        {
                            btnAddToCart.Text = originalText;
                            btnAddToCart.FillColor = originalColor;
                            btnAddToCart.Enabled = true;
                            resetTimer.Stop();
                            resetTimer.Dispose();
                        };
                        resetTimer.Start();
                    };
                    card.Controls.Add(btnAddToCart);
                }

                flowLayoutProducts.Controls.Add(card);
                item.CardPanel = card;
            }
        }

        private Image GetProductImage(string fileName, string productName, Color primaryColor)
        {
            string path1 = Path.Combine(Application.StartupPath, "Resources", fileName);
            if (File.Exists(path1))
            {
                try { return Image.FromFile(path1); } catch { }
            }

            string path2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Resources", fileName);
            if (File.Exists(path2))
            {
                try { return Image.FromFile(path2); } catch { }
            }

            Bitmap bmp = new Bitmap(290, 230);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    int radius = 16;
                    Rectangle rect = new Rectangle(5, 5, 280, 220);
                    path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                    path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                    path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                    path.CloseFigure();
                    using (Brush bgBrush = new SolidBrush(primaryColor))
                        g.FillPath(bgBrush, path);
                }

                if (productName.Contains("Kulaklık"))
                {
                    using (Pen p = new Pen(Color.FromArgb(50, 0, 0, 0), 10))
                        g.DrawArc(p, 85, 60, 120, 120, 180, 180);
                    using (Brush b = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
                    {
                        g.FillEllipse(b, 75, 110, 30, 50);
                        g.FillEllipse(b, 185, 110, 30, 50);
                    }
                }
                else if (productName.Contains("Konsol") || productName.Contains("Kolu"))
                {
                    using (Brush b = new SolidBrush(Color.White))
                    {
                        g.FillEllipse(b, 80, 90, 65, 65);
                        g.FillEllipse(b, 145, 90, 65, 65);
                        g.FillRectangle(b, 110, 95, 70, 45);
                    }
                    using (Brush b = new SolidBrush(Color.FromArgb(142, 68, 173)))
                    {
                        g.FillEllipse(b, 110, 115, 18, 18);
                        g.FillEllipse(b, 160, 115, 18, 18);
                    }
                }
                else if (productName.Contains("Kılıf"))
                {
                    using (Brush b = new SolidBrush(Color.FromArgb(250, 250, 250)))
                        g.FillRectangle(b, 90, 50, 110, 140);
                    using (Pen p = new Pen(Color.FromArgb(142, 68, 173), 3))
                        g.DrawRectangle(p, 90, 50, 110, 140);
                    using (Pen p = new Pen(Color.Coral, 2))
                    {
                        g.DrawArc(p, 100, 70, 30, 30, 0, 180);
                        g.DrawArc(p, 140, 120, 40, 40, 180, 180);
                    }
                }
                else if (productName.Contains("Crop") || productName.Contains("Telefon"))
                {
                    using (Brush b = new SolidBrush(Color.White))
                    {
                        g.FillRectangle(b, 100, 70, 90, 70);
                        g.FillRectangle(b, 75, 70, 25, 30);
                        g.FillRectangle(b, 190, 70, 25, 30);
                    }
                    using (Pen p = new Pen(Color.FromArgb(142, 68, 173), 3))
                        g.DrawLine(p, 100, 140, 190, 140);
                }
                else if (productName.Contains("Shorts") || productName.Contains("Bilgisayar"))
                {
                    using (Brush b = new SolidBrush(Color.FromArgb(40, 40, 40)))
                    {
                        g.FillRectangle(b, 95, 75, 100, 35);
                        g.FillRectangle(b, 95, 110, 45, 60);
                        g.FillRectangle(b, 150, 110, 45, 60);
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
                bool matchesStock = AppSession.IsAdmin || item.Stock > 0;

                if (item.CardPanel != null)
                    item.CardPanel.Visible = matchesCategory && matchesPrice && matchesSearch && matchesStock;
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

        private void tbPrice_ValueChanged(object sender, EventArgs e)
        {
            if (tbPrice != null && txtMaxPrice != null)
                txtMaxPrice.Text = tbPrice.Value.ToString();
        }

        private void txtMinPrice_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtMaxPrice_TextChanged(object sender, EventArgs e)
        {
            if (tbPrice != null && txtMaxPrice != null && int.TryParse(txtMaxPrice.Text, out int val))
            {
                if (val >= tbPrice.Minimum && val <= tbPrice.Maximum)
                    tbPrice.Value = val;
            }
        }

        private void btnDahaFazlaGor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblSeoDescription.Text = "Teknoloji Ürünleri – Türkiye'de online teknoloji alışverişi yapmak için en iyi web sitesini mi arıyorsunuz? O halde, yenilikçi ve güçlü teknolojik cihazlar için arayışınız burada sona eriyor. Günlük kullanıma uygun pratik akıllı cihazlardan, üst düzey performans sunan premium donanımlara kadar Emin Ticaret, en güncel ve en iyi teknoloji koleksiyonunu tek bir çatı altında sunuyor. Geniş teknoloji ürünleri yelpazemiz, seçimlerinizle dijital dünyada fark yaratmanızı ve her zaman bir adım önde olmanızı sağlayacak.\n\n" +
                                     "Tüm Teknoloji İhtiyaçlarınız İçin Tek Adres: Emin Ticaret\n\n" +
                                     "Günümüzde teknoloji, hayatımızın her alanında her zamankinden daha fazla yer kaplıyor. Artık yavaş ve kullanışsız cihazlarla vakit kaybettiğimiz günler geride kaldı. Bugün, hayatı kolaylaştıran akıllı donanımlar ve ergonomik tasarımlar, verimliliği ve konforu zirveye taşıyor. Bu doğrultuda Emin Ticaret, sizi işinizde, oyununuzda ve günlük yaşantınızda her zaman kazanan yapacak geniş bir premium teknoloji yelpazesine sahip.\n\n" +
                                     "Teknoloji koleksiyonumuz, dijital yaşam tarzınızda ikonik bir kalite standardı belirlemenizi sağlayacak. Şunu açıkça söyleyebiliriz ki; her zaman aradığınız o üstün donanım gücünü ve şık tasarımı bir arada sunan güvenilir teknoloji mağazalarının sayısı oldukça azdır. Emin ERP olarak biz, ürün yönetimini ve tedariğini sizler için en kolay ve şeffaf hale getirmek için buradayız.";

            lblSeoDescription.Height = 320;
            pnlSeoSection.Height = 450;
            pnlContent.Height = 1580;
            btnDahaFazlaGor.Visible = false;

            pnlContent.PerformLayout();
            pnlMainContainer.PerformLayout();
        }

        private void UpdateCartBadge()
        {
            int count = 0;
            foreach (var item in CartManager.Items)
                count += item.Quantity;
            btnCart.Text = count > 0 ? $"Sepet ({count})" : "Sepet";
        }

        private void btnCart_Click(object? sender, EventArgs e)
        {
            FormSepetPage f = new FormSepetPage(this);
            f.Show();
            this.Hide();
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
        public int Stock { get; set; } = 10;
    }
}
