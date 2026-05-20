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
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                throw new Exception("Kullanıcı adı boş bırakılamaz!");
            }
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new Exception("Şifre boş bırakılamaz!");
            }
            if (user.Password.Length < 3)
            {
                throw new Exception("Şifre en az 3 karakter olmalıdır!");
            }
            if (_userDal.CheckUserExists(user.Username))
            {
                throw new Exception("Bu kullanıcı adı zaten alınmış!");
            }

            _userDal.Add(user);
        }

        public void Register(string username, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Kullanıcı adı boş bırakılamaz!");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Şifre boş bırakılamaz!");
            }
            if (password != confirmPassword)
            {
                throw new Exception("Şifreler uyuşmuyor!");
            }
            if (password.Length < 3)
            {
                throw new Exception("Şifre en az 3 karakter olmalıdır!");
            }
            if (_userDal.CheckUserExists(username))
            {
                throw new Exception("Bu kullanıcı adı zaten alınmış!");
            }

            User user = new User { Username = username, Password = password };
            _userDal.Add(user);
        }

        public bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Kullanıcı adı boş bırakılamaz!");
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Şifre boş bırakılamaz!");

            if (!_userDal.CheckUserExists(username))
                throw new Exception("Geçersiz kullanıcı adı!");

            bool isSuccess = _userDal.CheckLogin(username, password);
            if (!isSuccess)
                throw new Exception("Hatalı şifre!");

            return true;
        }

        public void ResetPassword(string username, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Kullanıcı adı boş bırakılamaz!");
            }
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                throw new Exception("Yeni şifre boş bırakılamaz!");
            }
            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                throw new Exception("Yeni şifre tekrar alanı boş bırakılamaz!");
            }
            if (newPassword != confirmPassword)
            {
                throw new Exception("Şifreler uyuşmuyor!");
            }
            if (newPassword.Length < 3)
            {
                throw new Exception("Şifre en az 3 karakter olmalıdır!");
            }
            if (!_userDal.CheckUserExists(username))
            {
                throw new Exception("Geçersiz kullanıcı adı!");
            }

            _userDal.UpdatePassword(username, newPassword);
        }

        public void EnsureDatabaseCreated()
        {
            _userDal.EnsureDatabaseCreated();
        }
    }
}