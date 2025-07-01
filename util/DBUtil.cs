using System;
using MySql.Data.MySqlClient;

namespace MedicalStoreManagement.util
{
    public static class DBUtil
    {
        private static readonly string connectionString =
            "Server=localhost;Database=medicalStoreManagementDB;Uid=root;Pwd=root;";

        public static MySqlConnection GetConnection()
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            try
            {
                con.Open();
                return con;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Database connection failed: " + ex.Message);
                throw;
            }
        }
    }
}
