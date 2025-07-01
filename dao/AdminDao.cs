using System;
using MySql.Data.MySqlClient;
using MedicalStoreManagement.entities;
using MedicalStoreManagement.util;

namespace MedicalStoreManagement.dao
{
    public class AdminDao : IDisposable
    {
        private MySqlConnection connection;

        public AdminDao()
        {
            connection = DBUtil.GetConnection();
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        // Admin Login
        public Admin LoginAdmin(string email, string password)
        {
            string sql = "SELECT * FROM admin WHERE email = @email AND password = @password";

            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Admin admin = new Admin
                        {
                            Name = reader["name"].ToString(),
                            Email = reader["email"].ToString(),
                            Password = reader["password"].ToString()
                        };
                        return admin;
                    }
                }
            }

            return null;
        }
    }
}

