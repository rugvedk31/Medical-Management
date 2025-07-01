//using MedicalMangementSystem.main;
using MedicalStoreManagement.dao;
using MedicalStoreManagement.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStoreManagement.main
{
    public class MainMenu
    {
        // Admin login method
        private static Admin LoginAdmin()
        {
            Admin admin = null;

            try
            {
                using (AdminDao adminDao = new AdminDao())
                {
                    Console.Write("Enter the Email: ");
                    string email = Console.ReadLine();

                    Console.Write("Enter the Password: ");
                    string password = Console.ReadLine();

                    admin = adminDao.LoginAdmin(email, password);
                    if (admin != null)
                    {
                        Console.WriteLine($"Login successful. Welcome, {admin.Name}!");
                    }
                    else
                    {
                        Console.WriteLine("Admin not found...");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during login: " + ex.Message);
            }

            return admin;
        }

        // Display menu
        public static int ShowMainMenu()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Admin Login");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return choice;
            }
            return -1;
        }

        public static void Main(string[] args)
        {
            int choice;
            while ((choice = ShowMainMenu()) != 0)
            {
                switch (choice)
                {
                    case 1:
                        if (LoginAdmin() != null)
                        {
                            AdminSubMenu.Main2();
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }

            Console.WriteLine("Exiting... Thank you!");
        }
    }
}
