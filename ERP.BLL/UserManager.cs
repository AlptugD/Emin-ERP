using ERP.Entities;
using ERP.DAL;
using System;

namespace ERP.BLL
{
    public class UserManager
    {
        UserDal _userDal = new UserDal();

        public void Add(User user)
        {
            // Validasyon (Doğrulama) kuralları
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            {
                throw new Exception("Kullanıcı adı ve şifre boş bırakılamaz!");
            }
            if (user.Password.Length < 3)
            {
                throw new Exception("Şifre en az 3 karakter olmalıdır!");
            }

            _userDal.Add(user);
        }

        public bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new Exception("Lütfen bilgileri eksiksiz girin.");

            return _userDal.CheckLogin(username, password);
        }
    }
}