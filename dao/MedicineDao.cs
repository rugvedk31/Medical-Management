using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MedicalStoreManagement.entities;
using MedicalStoreManagement.util;

namespace MedicalStoreManagement.dao
{
    public class MedicineDao : IDisposable
    {
        private MySqlConnection connection;

        public MedicineDao()
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

        // Display All Medicines
        public List<Medicine> GetAllMedicines()
        {
            List<Medicine> medicines = new List<Medicine>();
            string sql = "SELECT * FROM medicines";

            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Medicine medicine = new Medicine
                        {
                            MedId = Convert.ToInt32(reader["med_id"]),
                            Name = reader["name"].ToString(),
                            Description = reader["description"].ToString(),
                            Price = reader["price"].ToString()
                        };

                        medicines.Add(medicine);
                    }
                }
            }

            return medicines;
        }

        // Add New Medicine
        public void AddMedicine(Medicine medicine)
        {
            string sql = "INSERT INTO medicines (name, description, price) VALUES (@name, @desc, @price)";

            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@name", medicine.Name);
                cmd.Parameters.AddWithValue("@desc", medicine.Description);
                cmd.Parameters.AddWithValue("@price", medicine.Price);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Medicine Added...");
            }
        }

        // Update Medicine Price
        public void UpdateMedicinePrice(int medId, string newPrice)
        {
            string sql = "UPDATE medicines SET price = @price WHERE med_id = @id";

            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@price", newPrice);
                cmd.Parameters.AddWithValue("@id", medId);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Medicine Price Updated...");
            }
        }

        // Delete Medicine
        public void DeleteMedicine(int medId)
        {
            string sql = "DELETE FROM medicines WHERE med_id = @id";

            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@id", medId);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Medicine Deleted...");
            }
        }

        // Get Sold Medicines
        public List<Medicine> GetSoldMedicines()
        {
            List<Medicine> soldMedicines = new List<Medicine>();

            string sql = @"SELECT m.med_id, m.name, m.description, m.price
                           FROM orders o
                           JOIN medicines m ON o.med_id = m.med_id";

            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Medicine medicine = new Medicine
                        {
                            MedId = Convert.ToInt32(reader["med_id"]),
                            Name = reader["name"].ToString(),
                            Description = reader["description"].ToString(),
                            Price = reader["price"].ToString()
                        };

                        soldMedicines.Add(medicine);
                    }
                }
            }

            return soldMedicines;
        }
    }
}
