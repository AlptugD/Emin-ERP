using ERP.BLL;
using System;
using System.Windows.Forms;

namespace ERP.UI
{
    public partial class FormKayitOl : Form
    {
        UserManager _userManager = new UserManager();

        public FormKayitOl()
        {
            InitializeComponent();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            try
            {
                _userManager.Register(txtKullaniciAdi.Text, txtSifre.Text, txtSifreTekrar.Text);
                MessageBox.Show("Kayıt başarıyla oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
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
