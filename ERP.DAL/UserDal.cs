using ERP.Entities;
using Microsoft.Data.SqlClient;

namespace ERP.DAL
{
    public class UserDal
    {
        public void Add(User user)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password) VALUES (@p1, @p2)", conn);
                cmd.Parameters.AddWithValue("@p1", user.Username);
                cmd.Parameters.AddWithValue("@p2", user.Password);
                cmd.ExecuteNonQuery();
            }
        }

        public bool CheckLogin(string username, string password)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username=@p1 AND Password=@p2", conn);
                cmd.Parameters.AddWithValue("@p1", username);
                cmd.Parameters.AddWithValue("@p2", password);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
    }
}