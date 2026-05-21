using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace ERP.UI
{
    partial class FormAdminStok
    {
        private System.ComponentModel.IContainer components = null;

        private Guna2Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblAdminBadge;
        private Guna2TextBox txtSearch;
        private FlowLayoutPanel flowLayoutProducts;
        private Guna2Button btnKaydet;
        private Guna2Button btnMagazayaGit;
        private Label lblHint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.pnlHeader = new Guna2Panel();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.lblAdminBadge = new Label();
            this.txtSearch = new Guna2TextBox();
            this.flowLayoutProducts = new FlowLayoutPanel();
            this.btnKaydet = new Guna2Button();
            this.btnMagazayaGit = new Guna2Button();
            this.lblHint = new Label();

            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.FillColor = Color.FromArgb(22, 22, 40);
            this.pnlHeader.BorderRadius = 0;
            this.pnlHeader.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.pnlHeader.Size = new Size(1000, 88);
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Controls.Add(this.lblAdminBadge);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.txtSearch);
            this.pnlHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // lblAdminBadge
            this.lblAdminBadge.Text = "ADMIN";
            this.lblAdminBadge.Font = new Font("Segoe UI Semibold", 7.5f, FontStyle.Bold);
            this.lblAdminBadge.ForeColor = Color.FromArgb(22, 22, 40);
            this.lblAdminBadge.BackColor = Color.FromArgb(100, 210, 150);
            this.lblAdminBadge.Location = new Point(20, 22);
            this.lblAdminBadge.Size = new Size(56, 18);
            this.lblAdminBadge.TextAlign = ContentAlignment.MiddleCenter;
            this.lblAdminBadge.AutoSize = false;

            // lblTitle
            this.lblTitle.Text = "Stok Yönetimi";
            this.lblTitle.Font = new Font("Segoe UI", 20f, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.BackColor = Color.Transparent;
            this.lblTitle.Location = new Point(86, 14);
            this.lblTitle.Size = new Size(300, 36);
            this.lblTitle.AutoSize = false;

            // lblSubtitle
            this.lblSubtitle.Text = "Ürün stoklarını liste görünümünden anlık olarak düzenleyin.";
            this.lblSubtitle.Font = new Font("Segoe UI", 9.5f);
            this.lblSubtitle.ForeColor = Color.FromArgb(170, 170, 195);
            this.lblSubtitle.BackColor = Color.Transparent;
            this.lblSubtitle.Location = new Point(88, 52);
            this.lblSubtitle.Size = new Size(450, 22);
            this.lblSubtitle.AutoSize = false;

            // txtSearch
            this.txtSearch.BackColor = Color.Transparent;
            this.txtSearch.BorderRadius = 15;
            this.txtSearch.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.txtSearch.DefaultText = "";
            this.txtSearch.FillColor = Color.FromArgb(35, 35, 55);
            this.txtSearch.BorderColor = Color.FromArgb(50, 50, 75);
            this.txtSearch.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            this.txtSearch.Font = new Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = Color.White;
            this.txtSearch.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            this.txtSearch.Location = new Point(680, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = Color.FromArgb(130, 130, 155);
            this.txtSearch.PlaceholderText = "🔍 Ürün veya Marka Ara...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.txtSearch.Size = new Size(290, 38);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // flowLayoutProducts
            this.flowLayoutProducts.Location = new Point(20, 108);
            this.flowLayoutProducts.Size = new Size(950, 480);
            this.flowLayoutProducts.AutoScroll = true;
            this.flowLayoutProducts.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutProducts.WrapContents = false;
            this.flowLayoutProducts.BackColor = Color.FromArgb(248, 248, 252);
            this.flowLayoutProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // lblHint
            this.lblHint.Text = "💡  Stok değerlerini değiştirin. Stok = 0 olan ürünler müşterilerin mağaza listesinde gizlenir.";
            this.lblHint.Font = new Font("Segoe UI", 9f);
            this.lblHint.ForeColor = Color.FromArgb(120, 120, 140);
            this.lblHint.Location = new Point(20, 615);
            this.lblHint.Size = new Size(520, 22);
            this.lblHint.AutoSize = false;

            // btnMagazayaGit
            this.btnMagazayaGit.Text = "🛍  Mağazaya Git";
            this.btnMagazayaGit.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
            this.btnMagazayaGit.FillColor = Color.FromArgb(40, 110, 220);
            this.btnMagazayaGit.ForeColor = Color.White;
            this.btnMagazayaGit.BorderRadius = 10;
            this.btnMagazayaGit.Size = new Size(180, 42);
            this.btnMagazayaGit.Location = new Point(570, 605);
            this.btnMagazayaGit.Cursor = Cursors.Hand;
            this.btnMagazayaGit.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.btnMagazayaGit.HoverState.FillColor = Color.FromArgb(28, 90, 195);
            this.btnMagazayaGit.Click += new System.EventHandler(this.btnMagazayaGit_Click);
            this.btnMagazayaGit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // btnKaydet
            this.btnKaydet.Text = "💾  Stokları Güncelle";
            this.btnKaydet.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
            this.btnKaydet.FillColor = Color.FromArgb(28, 160, 105);
            this.btnKaydet.ForeColor = Color.White;
            this.btnKaydet.BorderRadius = 10;
            this.btnKaydet.Size = new Size(200, 42);
            this.btnKaydet.Location = new Point(770, 605);
            this.btnKaydet.Cursor = Cursors.Hand;
            this.btnKaydet.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.btnKaydet.HoverState.FillColor = Color.FromArgb(22, 140, 90);
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            this.btnKaydet.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // FormAdminStok
            this.ClientSize = new Size(1000, 675);
            this.Text = "Admin – Stok Yönetimi | Emin ERP";
            this.BackColor = Color.FromArgb(248, 248, 252);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9.5f);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.flowLayoutProducts);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnMagazayaGit);
            this.Controls.Add(this.btnKaydet);

            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

            this.Load += new System.EventHandler(this.FormAdminStok_Load);
        }
    }
}
