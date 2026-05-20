using ERP.BLL;      // BLL katmanını tanımak için
using ERP.Entities; // User sınıfını tanımak için
using System;
using System.Windows.Forms;

namespace ERP.UI
{
    public partial class Form1 : Form
    {
        // 1. Manager sınıfımızı başlatıyoruz (BLL ile iletişim için)
        UserManager _userManager = new UserManager();

        public Form1()
        {
            InitializeComponent();
        }

        // 2. KAYIT OL butonuna çift tıklayıp bu kodu içine yapıştır
        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            try
            {
                // TextBox isimlerinin txtKullaniciAdi ve txtSifre olduğunu varsayıyorum
                User newUser = new User
                {
                    Username = txtKullaniciAdi.Text,
                    Password = txtSifre.Text
                };

                _userManager.Add(newUser);
                MessageBox.Show("Kayıt Başarıyla Oluşturuldu!", "Bilgi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata");
            }
        }

        // 3. GİRİŞ YAP butonuna çift tıklayıp bu kodu içine yapıştır
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            try
            {
                bool isSuccess = _userManager.Login(txtKullaniciAdi.Text, txtSifre.Text);

                if (isSuccess)
                {
                    MessageBox.Show("Giriş Başarılı!");
                    // İleride buraya başka bir form açtırma kodu gelecek
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

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}