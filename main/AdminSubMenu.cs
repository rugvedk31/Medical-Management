using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalStoreManagement.dao;
using MedicalStoreManagement.entities;

namespace MedicalStoreManagement.main
{
    public class AdminSubMenu
    {
        // Display Medicine Menu
        private static List<Medicine> DisplayMedicineMenu()
        {
            List<Medicine> medicineList = new List<Medicine>();

            try
            {
                using (MedicineDao medicineDao = new MedicineDao())
                {
                    medicineList = medicineDao.GetAllMedicines();

                    Console.WriteLine("+------+----------------------+--------------------------------------------+--------+");
                    Console.WriteLine("| mid  | name                 | description                               | price  |");
                    Console.WriteLine("+------+----------------------+--------------------------------------------+--------+");

                    foreach (Medicine m in medicineList)
                    {
                        Console.WriteLine(m.ToString());
                    }

                    Console.WriteLine("+------+----------------------+--------------------------------------------+--------+");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching medicines: " + ex.Message);
            }

            return medicineList;
        }

        // Add New Medicine
        public static void AddMedicine(Medicine medicine)
        {
            medicine.Accept();
            try
            {
                using (MedicineDao medicineDao = new MedicineDao())
                {
                    medicineDao.AddMedicine(medicine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding medicine: " + ex.Message);
            }
        }

        // Update Medicine Price
        public static void UpdateMedicine()
        {
            try
            {
                using (MedicineDao medicineDao = new MedicineDao())
                {
                    Console.Write("Enter the Medicine ID: ");
                    int mid = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter the New Price of Medicine: ");
                    string price = Console.ReadLine();

                    medicineDao.UpdateMedicinePrice(mid, price);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating medicine: " + ex.Message);
            }
        }

        // Delete Medicine
        public static void DeleteMedicine()
        {
            try
            {
                using (MedicineDao medicineDao = new MedicineDao())
                {
                    Console.Write("Enter the Medicine ID: ");
                    int mid = Convert.ToInt32(Console.ReadLine());

                    medicineDao.DeleteMedicine(mid);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting medicine: " + ex.Message);
            }
        }

        // Calculate Total Bill and Profit
        public static void CalculateTotalBillAndProfit()
        {
            double totalBill = 0.0;
            double totalProfit = 0.0;
            double profitMargin = 0.25; // 25% margin

            try
            {
                using (MedicineDao medicineDao = new MedicineDao())
                {
                    List<Medicine> soldMedicines = medicineDao.GetSoldMedicines();

                    foreach (Medicine medicine in soldMedicines)
                    {
                        if (double.TryParse(medicine.Price, out double price))
                        {
                            totalBill += price;
                            totalProfit += price * profitMargin;
                        }
                    }

                    Console.WriteLine($"Total Bill: {totalBill:F2}");
                    Console.WriteLine($"Total Profit: {totalProfit:F2}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error calculating bill/profit: " + ex.Message);
            }
        }

        // Admin Menu
        public static int ShowAdminMenu()
        {
            Console.WriteLine("0. Logout");
            Console.WriteLine("1. View All Medicines");
            Console.WriteLine("2. Add New Medicine");
            Console.WriteLine("3. Update Medicine Price");
            Console.WriteLine("4. Delete Medicine");
            Console.WriteLine("5. Calculate Total Bill and Profit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
                return choice;
            return -1;
        }

        public static void Main2()
        {
            int choice;

            while ((choice = ShowAdminMenu()) != 0)
            {
                switch (choice)
                {
                    case 1:
                        DisplayMedicineMenu();
                        break;

                    case 2:
                        Medicine newMedicine = new Medicine();
                        AddMedicine(newMedicine);
                        break;

                    case 3:
                        UpdateMedicine();
                        break;

                    case 4:
                        DeleteMedicine();
                        break;

                    case 5:
                        CalculateTotalBillAndProfit();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }

            Console.WriteLine("Logged out successfully.");
        }
    }
}
