using ERP.BLL;
using ERP.Entities;
using System;
using System.Windows.Forms;

namespace ERP.UI  // <--- BURAYA ÇOK DİKKAT ET! Projenin sağ taraftaki adıyla birebir aynı olmalı.
{
    public partial class Form1 : Form
    {
        UserManager _userManager = new UserManager();

        public Form1()
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
                    MessageBox.Show("Giriş Başarılı!", "Bilgi");
                    this.Hide();
                    // FormAnaMenu anaMenu = new FormAnaMenu();
                    // anaMenu.Show();
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
    }
}