namespace ERP.UI
{
    partial class FormGiris
    {



        private System.ComponentModel.IContainer components = null;





        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code





        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnGirisYap = new Guna.UI2.WinForms.Guna2Button();
            btnKayitOl = new Guna.UI2.WinForms.Guna2Button();
            linkLabel1 = new LinkLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel8 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            txtKullaniciAdi = new Guna.UI2.WinForms.Guna2TextBox();
            txtSifre = new Guna.UI2.WinForms.Guna2TextBox();
            lblGizleGoster = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel10 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();



            btnGirisYap.BorderRadius = 15;
            btnGirisYap.BorderThickness = 1;
            btnGirisYap.CustomizableEdges = customizableEdges1;
            btnGirisYap.DisabledState.BorderColor = Color.DarkGray;
            btnGirisYap.DisabledState.CustomBorderColor = Color.DarkGray;
            btnGirisYap.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnGirisYap.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnGirisYap.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnGirisYap.ForeColor = Color.White;
            btnGirisYap.Location = new Point(669, 487);
            btnGirisYap.Name = "btnGirisYap";
            btnGirisYap.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnGirisYap.Size = new Size(174, 56);
            btnGirisYap.TabIndex = 2;
            btnGirisYap.Text = "Giriş Yap";
            btnGirisYap.Click += btnGirisYap_Click;



            btnKayitOl.BorderRadius = 15;
            btnKayitOl.CustomizableEdges = customizableEdges3;
            btnKayitOl.DisabledState.BorderColor = Color.DarkGray;
            btnKayitOl.DisabledState.CustomBorderColor = Color.DarkGray;
            btnKayitOl.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnKayitOl.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnKayitOl.FillColor = Color.White;
            btnKayitOl.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnKayitOl.ForeColor = SystemColors.Highlight;
            btnKayitOl.Location = new Point(1087, 25);
            btnKayitOl.Name = "btnKayitOl";
            btnKayitOl.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnKayitOl.Size = new Size(174, 56);
            btnKayitOl.TabIndex = 3;
            btnKayitOl.Text = "Kayıt Ol";
            btnKayitOl.Click += btnKayitOl_Click;



            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(1144, 450);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(117, 20);
            linkLabel1.TabIndex = 10;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Şifremi Unuttum";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;



            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            guna2HtmlLabel1.Location = new Point(51, 29);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(3, 2);
            guna2HtmlLabel1.TabIndex = 5;
            guna2HtmlLabel1.Text = null;



            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Location = new Point(51, 78);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(161, 22);
            guna2HtmlLabel2.TabIndex = 6;
            guna2HtmlLabel2.Text = "Ürünleriniz Emin Ellerde";



            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            guna2HtmlLabel3.Location = new Point(593, 152);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(285, 39);
            guna2HtmlLabel3.TabIndex = 7;
            guna2HtmlLabel3.Text = "Hesabınıza Giriş Yapınız";



            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            guna2HtmlLabel4.Location = new Point(593, 217);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(153, 19);
            guna2HtmlLabel4.TabIndex = 8;
            guna2HtmlLabel4.Text = "E posta Veya Kullanıcı Adı";



            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            guna2HtmlLabel5.Location = new Point(593, 319);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(29, 19);
            guna2HtmlLabel5.TabIndex = 9;
            guna2HtmlLabel5.Text = "Şifre";



            guna2HtmlLabel6.BackColor = Color.Transparent;
            guna2HtmlLabel6.Font = new Font("Segoe UI", 18F);
            guna2HtmlLabel6.Location = new Point(63, 12);
            guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            guna2HtmlLabel6.Size = new Size(126, 43);
            guna2HtmlLabel6.TabIndex = 11;
            guna2HtmlLabel6.Text = "Emin ERP";



            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Font = new Font("Segoe UI", 14F);
            guna2HtmlLabel7.Location = new Point(669, 162);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(246, 33);
            guna2HtmlLabel7.TabIndex = 12;
            guna2HtmlLabel7.Text = "Hesabınıza Giriş Yapınız";



            guna2HtmlLabel8.BackColor = Color.Transparent;
            guna2HtmlLabel8.Location = new Point(669, 253);
            guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            guna2HtmlLabel8.Size = new Size(174, 22);
            guna2HtmlLabel8.TabIndex = 13;
            guna2HtmlLabel8.Text = "E Posta Veya Kullanıcı Adı";



            guna2HtmlLabel9.BackColor = Color.Transparent;
            guna2HtmlLabel9.Location = new Point(669, 357);
            guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            guna2HtmlLabel9.Size = new Size(33, 22);
            guna2HtmlLabel9.TabIndex = 14;
            guna2HtmlLabel9.Text = "Şifre";



            guna2Elipse1.BorderRadius = 15;
            guna2Elipse1.TargetControl = this;



            guna2PictureBox1.BorderRadius = 20;
            guna2PictureBox1.CustomizableEdges = customizableEdges9;
            guna2PictureBox1.Image = Properties.Resources.side_image;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(28, 121);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2PictureBox1.Size = new Size(595, 514);
            guna2PictureBox1.TabIndex = 15;
            guna2PictureBox1.TabStop = false;



            txtKullaniciAdi.BorderColor = Color.Black;
            txtKullaniciAdi.BorderRadius = 8;
            txtKullaniciAdi.CustomizableEdges = customizableEdges7;
            txtKullaniciAdi.DefaultText = "";
            txtKullaniciAdi.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtKullaniciAdi.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtKullaniciAdi.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtKullaniciAdi.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtKullaniciAdi.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtKullaniciAdi.Font = new Font("Segoe UI", 9F);
            txtKullaniciAdi.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtKullaniciAdi.Location = new Point(657, 289);
            txtKullaniciAdi.Margin = new Padding(3, 4, 3, 4);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.PlaceholderText = "";
            txtKullaniciAdi.SelectedText = "";
            txtKullaniciAdi.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtKullaniciAdi.Size = new Size(604, 61);
            txtKullaniciAdi.TabIndex = 16;



            txtSifre.BorderColor = Color.Black;
            txtSifre.BorderRadius = 8;
            txtSifre.CustomizableEdges = customizableEdges5;
            txtSifre.DefaultText = "";
            txtSifre.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSifre.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSifre.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSifre.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSifre.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSifre.Font = new Font("Segoe UI", 9F);
            txtSifre.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSifre.IconRightCursor = Cursors.Hand;
            txtSifre.Location = new Point(657, 385);
            txtSifre.Margin = new Padding(3, 4, 3, 4);
            txtSifre.Name = "txtSifre";
            txtSifre.PlaceholderText = "";
            txtSifre.SelectedText = "";
            txtSifre.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtSifre.Size = new Size(604, 61);
            txtSifre.TabIndex = 17;
            txtSifre.UseSystemPasswordChar = true;



            lblGizleGoster.BackColor = Color.Transparent;
            lblGizleGoster.Location = new Point(1189, 404);
            lblGizleGoster.Name = "lblGizleGoster";
            lblGizleGoster.Size = new Size(46, 22);
            lblGizleGoster.Cursor = Cursors.Hand;
            lblGizleGoster.TabIndex = 18;
            lblGizleGoster.Text = "Göster";
            lblGizleGoster.Click += lblGizleGoster_Click;



            guna2HtmlLabel10.BackColor = Color.Transparent;
            guna2HtmlLabel10.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            guna2HtmlLabel10.ForeColor = Color.FromArgb(127, 140, 141);
            guna2HtmlLabel10.Location = new Point(63, 73);
            guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            guna2HtmlLabel10.Size = new Size(185, 25);
            guna2HtmlLabel10.TabIndex = 19;
            guna2HtmlLabel10.Text = "Ürünleriniz emin ellerde";



            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1353, 713);
            Controls.Add(guna2HtmlLabel10);
            Controls.Add(lblGizleGoster);
            Controls.Add(txtSifre);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(guna2PictureBox1);
            Controls.Add(guna2HtmlLabel9);
            Controls.Add(guna2HtmlLabel8);
            Controls.Add(guna2HtmlLabel7);
            Controls.Add(guna2HtmlLabel6);
            Controls.Add(linkLabel1);
            Controls.Add(btnKayitOl);
            Controls.Add(btnGirisYap);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormGiris";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnGirisYap;
        private Guna.UI2.WinForms.Guna2Button btnKayitOl;
        private LinkLabel linkLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel8;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel10;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGizleGoster;
        private Guna.UI2.WinForms.Guna2TextBox txtSifre;
        private Guna.UI2.WinForms.Guna2TextBox txtKullaniciAdi;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}
