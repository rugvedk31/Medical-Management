using System;

namespace MedicalStoreManagement.entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int MedId { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public Order()
        {
        }

        public Order(int orderId, int medId, int quantity, double totalPrice)
        {
            OrderId = orderId;
            MedId = medId;
            Quantity = quantity;
            TotalPrice = totalPrice;
        }

        public override string ToString()
        {
            return string.Format("{0,-8} {1,-8} {2,-10} {3,-10:F2}", OrderId, MedId, Quantity, TotalPrice);
        }
    }
}
