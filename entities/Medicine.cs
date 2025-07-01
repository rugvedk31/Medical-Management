using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalStoreManagement.entities
{
    public class Medicine
    {
        public int MedId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public void Accept()
        {
            Console.Write("Enter the Name: ");
            Name = Console.ReadLine();

            Console.Write("Enter the Description: ");
            Description = Console.ReadLine();

            Console.Write("Enter the Price: ");
            Price = Console.ReadLine();
        }

        public override string ToString()
        {
            return string.Format("| {0,-6} | {1,-20} | {2,-40} | {3,-6} |", MedId, Name, Description, Price);
        }
    }
}

