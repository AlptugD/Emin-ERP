using ERP.BLL;
using System;
using System.Windows.Forms;

namespace ERP.UI
{
    public partial class FormSifremiUnuttum : Form
    {
        UserManager _userManager = new UserManager();

        public FormSifremiUnuttum()
        {
            InitializeComponent();
        }

        private void btnSifreSifirla_Click(object sender, EventArgs e)
        {
            try
            {
                _userManager.ResetPassword(txtKullaniciAdi.Text, txtYeniSifre.Text, txtSifreTekrar.Text);
                MessageBox.Show("Şifreniz başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Return to login
                FormGiris loginForm = new FormGiris();
                loginForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGirisYapDon_Click(object sender, EventArgs e)
        {
            FormGiris loginForm = new FormGiris();
            loginForm.Show();
            this.Close();
        }
    }
}
