using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using ERP.Entities;

namespace ERP.UI
{
    public partial class FormAdminStok : Form
    {
        public FormAdminStok()
        {
            InitializeComponent();
            this.FormClosed += (s, ev) => Application.Exit();
        }

        private void FormAdminStok_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text.Trim().ToLower());
        }

        private void LoadProducts(string searchFilter = "")
        {
            flowLayoutProducts.Controls.Clear();

            foreach (var p in ProductCatalog.Products)
            {

                if (!string.IsNullOrEmpty(searchFilter))
                {
                    bool matchesName = p.Name.ToLower().Contains(searchFilter);
                    bool matchesBrand = p.Brand.ToLower().Contains(searchFilter);
                    bool matchesCategory = p.Category.ToLower().Contains(searchFilter);
                    if (!matchesName && !matchesBrand && !matchesCategory)
                        continue;
                }


                Guna2Panel card = new Guna2Panel();
                card.Size = new Size(910, 80);
                card.BorderColor = p.Stock > 0 ? Color.FromArgb(235, 235, 245) : Color.FromArgb(255, 205, 205);
                card.BorderThickness = 1;
                card.BorderRadius = 12;
                card.FillColor = p.Stock > 0 ? Color.White : Color.FromArgb(255, 250, 250);
                card.Margin = new Padding(5, 5, 5, 8);
                card.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();


                Guna2PictureBox pb = new Guna2PictureBox();
                pb.Size = new Size(60, 60);
                pb.Location = new Point(10, 10);
                pb.BorderRadius = 8;
                pb.Image = GetProductImage(p.ImageFileName, p.Name, p.PrimaryColor);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                card.Controls.Add(pb);


                Label lblName = new Label();
                lblName.Text = p.Name;
                lblName.Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold);
                lblName.ForeColor = Color.FromArgb(40, 40, 60);
                lblName.Location = new Point(85, 16);
                lblName.Size = new Size(290, 24);
                lblName.BackColor = Color.Transparent;
                card.Controls.Add(lblName);


                Label lblSub = new Label();
                lblSub.Text = $"{p.Brand}  •  {p.Category}";
                lblSub.Font = new Font("Segoe UI", 8.5f);
                lblSub.ForeColor = Color.FromArgb(140, 140, 160);
                lblSub.Location = new Point(85, 42);
                lblSub.Size = new Size(290, 20);
                lblSub.BackColor = Color.Transparent;
                card.Controls.Add(lblSub);


                Guna2Button btnPrice = new Guna2Button();
                btnPrice.Text = p.Price.ToString("N2") + " TL";
                btnPrice.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                btnPrice.FillColor = Color.FromArgb(245, 246, 250);
                btnPrice.ForeColor = Color.FromArgb(50, 50, 75);
                btnPrice.BorderColor = Color.FromArgb(230, 230, 240);
                btnPrice.BorderThickness = 1;
                btnPrice.BorderRadius = 8;
                btnPrice.Size = new Size(130, 32);
                btnPrice.Location = new Point(380, 24);
                btnPrice.Cursor = Cursors.Default;
                btnPrice.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                card.Controls.Add(btnPrice);


                Label lblStockTag = new Label();
                lblStockTag.Text = "Stok:";
                lblStockTag.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                lblStockTag.ForeColor = Color.FromArgb(100, 100, 120);
                lblStockTag.Location = new Point(530, 30);
                lblStockTag.Size = new Size(45, 20);
                lblStockTag.BackColor = Color.Transparent;
                card.Controls.Add(lblStockTag);


                Guna2Button btnStatus = new Guna2Button();
                btnStatus.Font = new Font("Segoe UI Semibold", 8f, FontStyle.Bold);
                btnStatus.Size = new Size(115, 32);
                btnStatus.Location = new Point(765, 24);
                btnStatus.Cursor = Cursors.Default;
                btnStatus.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();


                Guna2TextBox txtStock = new Guna2TextBox();
                txtStock.Text = p.Stock.ToString();
                txtStock.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
                txtStock.Size = new Size(80, 34);
                txtStock.Location = new Point(575, 23);
                txtStock.TextAlign = HorizontalAlignment.Center;
                txtStock.BorderRadius = 8;
                txtStock.BorderColor = Color.FromArgb(200, 200, 220);
                txtStock.Tag = p;
                txtStock.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();


                Action UpdateStatusBadge = () =>
                {
                    if (int.TryParse(txtStock.Text.Trim(), out int val) && val > 0)
                    {
                        btnStatus.Text = "STOKTA VAR";
                        btnStatus.FillColor = Color.FromArgb(230, 248, 240);
                        btnStatus.ForeColor = Color.FromArgb(28, 160, 105);
                        card.BorderColor = Color.FromArgb(235, 235, 245);
                        card.FillColor = Color.White;
                    }
                    else
                    {
                        btnStatus.Text = "TÜKENDİ";
                        btnStatus.FillColor = Color.FromArgb(255, 235, 235);
                        btnStatus.ForeColor = Color.FromArgb(220, 53, 69);
                        card.BorderColor = Color.FromArgb(255, 205, 205);
                        card.FillColor = Color.FromArgb(255, 250, 250);
                    }
                };


                UpdateStatusBadge();


                txtStock.TextChanged += (senderText, eText) =>
                {
                    UpdateStatusBadge();
                };

                card.Controls.Add(txtStock);
                card.Controls.Add(btnStatus);

                flowLayoutProducts.Controls.Add(card);
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

            Bitmap bmp = new Bitmap(60, 60);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    int radius = 10;
                    Rectangle rect = new Rectangle(2, 2, 56, 56);
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
                    using (Pen p = new Pen(Color.FromArgb(40, 0, 0, 0), 4))
                        g.DrawArc(p, 15, 12, 30, 30, 180, 180);
                    using (Brush b = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
                    {
                        g.FillEllipse(b, 12, 25, 8, 14);
                        g.FillEllipse(b, 40, 25, 8, 14);
                    }
                }
                else if (productName.Contains("Konsol") || productName.Contains("Kolu"))
                {
                    using (Brush b = new SolidBrush(Color.White))
                    {
                        g.FillEllipse(b, 12, 18, 18, 18);
                        g.FillEllipse(b, 30, 18, 18, 18);
                        g.FillRectangle(b, 20, 20, 20, 14);
                    }
                    using (Brush b = new SolidBrush(Color.FromArgb(142, 68, 173)))
                    {
                        g.FillEllipse(b, 17, 24, 5, 5);
                        g.FillEllipse(b, 37, 24, 5, 5);
                    }
                }
                else if (productName.Contains("Kılıf"))
                {
                    using (Brush b = new SolidBrush(Color.FromArgb(250, 250, 250)))
                        g.FillRectangle(b, 18, 10, 24, 40);
                    using (Pen p = new Pen(Color.FromArgb(142, 68, 173), 1.5f))
                        g.DrawRectangle(p, 18, 10, 24, 40);
                    using (Pen p = new Pen(Color.Coral, 1))
                    {
                        g.DrawArc(p, 20, 15, 10, 10, 0, 180);
                        g.DrawArc(p, 26, 30, 12, 12, 180, 180);
                    }
                }
                else if (productName.Contains("Crop") || productName.Contains("Telefon"))
                {
                    using (Brush b = new SolidBrush(Color.White))
                    {
                        g.FillRectangle(b, 18, 15, 24, 20);
                        g.FillRectangle(b, 12, 15, 6, 8);
                        g.FillRectangle(b, 42, 15, 6, 8);
                    }
                    using (Pen p = new Pen(Color.FromArgb(142, 68, 173), 1.5f))
                        g.DrawLine(p, 18, 35, 42, 35);
                }
                else if (productName.Contains("Shorts") || productName.Contains("Bilgisayar"))
                {
                    using (Brush b = new SolidBrush(Color.FromArgb(40, 40, 40)))
                    {
                        g.FillRectangle(b, 16, 15, 28, 10);
                        g.FillRectangle(b, 16, 25, 13, 20);
                        g.FillRectangle(b, 31, 25, 13, 20);
                    }
                }
            }
            return bmp;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                int saveCount = 0;


                foreach (Control cardControl in flowLayoutProducts.Controls)
                {
                    if (cardControl is Guna2Panel panel)
                    {
                        foreach (Control sub in panel.Controls)
                        {
                            if (sub is Guna2TextBox txtStock && txtStock.Tag is ProductItem product)
                            {
                                if (int.TryParse(txtStock.Text.Trim(), out int stockVal) && stockVal >= 0)
                                {
                                    product.Stock = stockVal;
                                    ProductCatalog.UpdateStock(product.Id, stockVal);
                                    saveCount++;
                                }
                                else
                                {
                                    MessageBox.Show($"'{product.Name}' ürünü için geçersiz stok değeri girildi! Lütfen pozitif bir tam sayı girin.", "Geçersiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                            }
                        }
                    }
                }

                MessageBox.Show($"{saveCount} adet ürünün stok bilgisi başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProducts(txtSearch.Text.Trim().ToLower());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stoklar güncellenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMagazayaGit_Click(object sender, EventArgs e)
        {
            FormAnaMenu anaMenu = new FormAnaMenu();
            anaMenu.ExitOnClose = false;
            anaMenu.FormClosed += (s, ev) => { this.Show(); LoadProducts(); };
            anaMenu.Show();
            this.Hide();
        }
    }
}
