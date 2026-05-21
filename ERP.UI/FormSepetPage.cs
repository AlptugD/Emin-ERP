using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ERP.UI
{
    public partial class FormSepetPage : Form
    {
        private FormAnaMenu mainForm;

        public FormSepetPage(FormAnaMenu mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.FormClosed += (s, ev) => Application.Exit();
            
            CartManager.CartChanged += LoadCartItems;
        }

        private void FormSepetPage_Load(object sender, EventArgs e)
        {
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            // Clear current list
            flowLayoutCartItems.Controls.Clear();
            
            double subtotal = 0;
            double shipping = CartManager.Items.Count > 0 ? 50.00 : 0.00;

            foreach (var item in CartManager.Items)
            {
                double lineTotal = item.Product.Price * item.Quantity;
                subtotal += lineTotal;

                // Create a container panel for the row
                Guna2Panel rowPanel = new Guna2Panel();
                rowPanel.Size = new Size(1250, 100);
                rowPanel.BorderColor = Color.FromArgb(235, 235, 235);
                rowPanel.BorderThickness = 1;
                rowPanel.BorderRadius = 8;
                rowPanel.FillColor = Color.White;
                rowPanel.Margin = new Padding(0, 0, 0, 10);
                rowPanel.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();

                // 1. Product Image
                Guna2PictureBox pb = new Guna2PictureBox();
                pb.Size = new Size(70, 70);
                pb.Location = new Point(15, 15);
                pb.BorderRadius = 6;
                pb.Image = GetProductImage(item.Product.ImageFileName, item.Product.Name, item.Product.PrimaryColor);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                rowPanel.Controls.Add(pb);

                // 2. Product Name and Variant
                Label lblName = new Label();
                lblName.Text = item.Product.Name;
                lblName.Font = new Font("Segoe UI Semibold", 10.0f, FontStyle.Bold);
                lblName.Location = new Point(100, 25);
                lblName.Size = new Size(350, 22);
                lblName.ForeColor = Color.FromArgb(40, 40, 40);
                rowPanel.Controls.Add(lblName);

                Label lblVariant = new Label();
                lblVariant.Text = "Renk: Standart"; // Default variant
                lblVariant.Font = new Font("Segoe UI", 8.5f);
                lblVariant.Location = new Point(100, 50);
                lblVariant.Size = new Size(350, 20);
                lblVariant.ForeColor = Color.DarkGray;
                rowPanel.Controls.Add(lblVariant);

                // 3. Price
                Label lblPrice = new Label();
                lblPrice.Text = $"{item.Product.Price:N2} TL";
                lblPrice.Font = new Font("Segoe UI Semibold", 10.0f, FontStyle.Bold);
                lblPrice.Location = new Point(480, 38);
                lblPrice.Size = new Size(120, 24);
                lblPrice.ForeColor = Color.FromArgb(50, 50, 50);
                rowPanel.Controls.Add(lblPrice);

                // 4. Quantity Selector Panel
                Guna2Panel pnlQty = new Guna2Panel();
                pnlQty.Size = new Size(95, 30);
                pnlQty.Location = new Point(660, 35);
                pnlQty.BorderColor = Color.FromArgb(220, 220, 220);
                pnlQty.BorderThickness = 1;
                pnlQty.BorderRadius = 6;
                pnlQty.FillColor = Color.FromArgb(248, 249, 250);
                pnlQty.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();

                Button btnMinus = new Button();
                btnMinus.Text = "-";
                btnMinus.Size = new Size(25, 28);
                btnMinus.Location = new Point(1, 1);
                btnMinus.FlatStyle = FlatStyle.Flat;
                btnMinus.FlatAppearance.BorderSize = 0;
                btnMinus.BackColor = Color.FromArgb(235, 235, 235);
                btnMinus.ForeColor = Color.FromArgb(60, 60, 60);
                btnMinus.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                btnMinus.Cursor = Cursors.Hand;
                btnMinus.Click += (s, ev) => {
                    CartManager.Remove(item.Product);
                };
                pnlQty.Controls.Add(btnMinus);

                Label lblQty = new Label();
                lblQty.Text = item.Quantity.ToString();
                lblQty.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                lblQty.Location = new Point(27, 3);
                lblQty.Size = new Size(41, 24);
                lblQty.TextAlign = ContentAlignment.MiddleCenter;
                lblQty.ForeColor = Color.FromArgb(40, 40, 40);
                pnlQty.Controls.Add(lblQty);

                Button btnPlus = new Button();
                btnPlus.Text = "+";
                btnPlus.Size = new Size(25, 28);
                btnPlus.Location = new Point(69, 1);
                btnPlus.FlatStyle = FlatStyle.Flat;
                btnPlus.FlatAppearance.BorderSize = 0;
                btnPlus.BackColor = Color.FromArgb(235, 235, 235);
                btnPlus.ForeColor = Color.FromArgb(60, 60, 60);
                btnPlus.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
                btnPlus.Cursor = Cursors.Hand;
                btnPlus.Click += (s, ev) => {
                    CartManager.Add(item.Product);
                };
                pnlQty.Controls.Add(btnPlus);

                btnMinus.BringToFront();
                btnPlus.BringToFront();
                lblQty.BringToFront();

                rowPanel.Controls.Add(pnlQty);

                // 5. Shipping
                Label lblShip = new Label();
                lblShip.Text = "Ücretsiz Kargo";
                lblShip.Font = new Font("Segoe UI", 9.5f);
                lblShip.Location = new Point(830, 38);
                lblShip.Size = new Size(120, 24);
                lblShip.ForeColor = Color.Gray;
                rowPanel.Controls.Add(lblShip);

                // 6. Subtotal
                Label lblLineTotal = new Label();
                lblLineTotal.Text = $"{lineTotal:N2} TL";
                lblLineTotal.Font = new Font("Segoe UI Semibold", 10.0f, FontStyle.Bold);
                lblLineTotal.Location = new Point(1000, 38);
                lblLineTotal.Size = new Size(120, 24);
                lblLineTotal.ForeColor = Color.FromArgb(50, 50, 50);
                rowPanel.Controls.Add(lblLineTotal);

                // 7. Delete action button (trash bin)
                Guna2Button btnDelete = new Guna2Button();
                btnDelete.Text = "🗑";
                btnDelete.Font = new Font("Segoe UI", 11.5f);
                btnDelete.FillColor = Color.Transparent;
                btnDelete.ForeColor = Color.FromArgb(180, 80, 80);
                btnDelete.HoverState.ForeColor = Color.Red;
                btnDelete.Size = new Size(35, 35);
                btnDelete.Location = new Point(1190, 32);
                btnDelete.Cursor = Cursors.Hand;
                btnDelete.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
                btnDelete.Click += (s, ev) => {
                    // Fully remove product from cart
                    CartManager.Items.Remove(item);
                    CartManager.TriggerChanged();
                };
                rowPanel.Controls.Add(btnDelete);

                flowLayoutCartItems.Controls.Add(rowPanel);
            }

            // Adjust heights of controls to prevent inner scroll clipping and enable main page scroll
            int itemCount = CartManager.Items.Count;
            flowLayoutCartItems.Height = Math.Max(120, itemCount * 110 + 10);
            
            // Adjust coordinates of summary, footer panels
            pnlSummary.Location = new Point(770, flowLayoutCartItems.Bottom + 20);
            pnlFooter.Location = new Point(0, pnlSummary.Bottom + 50);
            
            // Set the content height dynamically so the parent auto-scroll panel works correctly
            pnlContent.Height = pnlFooter.Bottom;

            // Calculations
            double total = subtotal + shipping;
            lblSubtotalValue.Text = $"{subtotal:N2} TL";
            lblShippingValue.Text = $"{shipping:N2} TL";
            lblTotalValue.Text = $"{total:N2} TL";

            // Badge count in Header
            int totalQty = 0;
            foreach (var item in CartManager.Items)
            {
                totalQty += item.Quantity;
            }
            btnCartHeader.Text = totalQty > 0 ? $"🛒 ({totalQty})" : "🛒";

            if (itemCount == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Sepetiniz boş. Alışverişe başlamak için ürünleri inceleyin!";
                lblEmpty.Font = new Font("Segoe UI Semibold", 11.0f, FontStyle.Italic);
                lblEmpty.ForeColor = Color.Gray;
                lblEmpty.Size = new Size(1250, 100);
                lblEmpty.TextAlign = ContentAlignment.MiddleCenter;
                flowLayoutCartItems.Controls.Add(lblEmpty);
            }
        }

        private Image GetProductImage(string fileName, string productName, Color primaryColor)
        {
            // Same helper method as FormAnaMenu to draw nice vector images
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

            Bitmap bmp = new Bitmap(70, 70);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Brush bgBrush = new SolidBrush(primaryColor))
                {
                    g.FillEllipse(bgBrush, 5, 5, 60, 60);
                }
                using (Pen p = new Pen(Color.White, 3))
                {
                    g.DrawEllipse(p, 5, 5, 60, 60);
                }
            }
            return bmp;
        }

        private void btnGoToCheckout_Click(object sender, EventArgs e)
        {
            if (CartManager.Items.Count == 0)
            {
                MessageBox.Show("Sepetinizde ürün bulunmamaktadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Ödeme ekranına yönlendiriliyorsunuz... Siparişiniz alınmıştır!", "Ödeme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CartManager.Clear();
            GoBackToHome();
        }

        private void GoBackToHome()
        {
            mainForm.Show();
            this.Hide();
        }

        private void lnkMenuHome_Click(object sender, EventArgs e)
        {
            GoBackToHome();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            CartManager.CartChanged -= LoadCartItems;
            base.OnFormClosed(e);
        }
    }
}
