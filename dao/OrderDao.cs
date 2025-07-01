using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MedicalStoreManagement.util;
using OrderEntity = MedicalStoreManagement.entities.Order; // Fix for ambiguity

namespace MedicalStoreManagement.dao
{
    public class OrderDao
    {
        public List<OrderEntity> GetAllOrders()
        {
            List<OrderEntity> orderList = new List<OrderEntity>();

            try
            {
                using (MySqlConnection con = DBUtil.GetConnection())
                {
                    string sql = "SELECT * FROM orders";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrderEntity order = new OrderEntity
                                {
                                    OrderId = Convert.ToInt32(reader["order_id"]),
                                    MedId = Convert.ToInt32(reader["med_id"]),
                                    Quantity = Convert.ToInt32(reader["quantity"]),
                                    TotalPrice = Convert.ToDouble(reader["total_price"])
                                };

                                orderList.Add(order);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return orderList;
        }
    }
}
