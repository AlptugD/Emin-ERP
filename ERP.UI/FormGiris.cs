using ERP.BLL;
using ERP.Entities;
using System;
using System.Windows.Forms;

namespace ERP.UI
{
    public partial class FormGiris : Form
    {
        UserManager _userManager = new UserManager();

        public FormGiris()
        {
            InitializeComponent();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            FormKayitOl kayitForm = new FormKayitOl();
            kayitForm.Show();
            this.Hide();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            try
            {
                bool isSuccess = _userManager.Login(txtKullaniciAdi.Text, txtSifre.Text);

                if (isSuccess)
                {
                    AppSession.IsAdmin = txtKullaniciAdi.Text.Trim().ToLower() == "admin";
                    AppSession.CurrentUsername = txtKullaniciAdi.Text.Trim();

                    MessageBox.Show("Giriş Başarılı!", "Bilgi");
                    this.Hide();

                    if (AppSession.IsAdmin)
                    {
                        FormAdminStok adminForm = new FormAdminStok();
                        adminForm.Show();
                    }
                    else
                    {
                        FormAnaMenu anaMenu = new FormAnaMenu();
                        anaMenu.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı adı veya şifre!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSifremiUnuttum forgotForm = new FormSifremiUnuttum();
            forgotForm.Show();
            this.Hide();
        }

        private void lblGizleGoster_Click(object sender, EventArgs e)
        {
            if (txtSifre.UseSystemPasswordChar)
            {
                txtSifre.UseSystemPasswordChar = false;
                lblGizleGoster.Text = "Gizle";
            }
            else
            {
                txtSifre.UseSystemPasswordChar = true;
                lblGizleGoster.Text = "Göster";
            }
        }
    }
}