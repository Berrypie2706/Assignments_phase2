using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8
{
    public class OrderClass
    {
        static Assignment08DbEntities db;
        public static void ReadOrder()
        {
            db = new Assignment08DbEntities();
            foreach (Order order in db.Orders)
            {
                Console.WriteLine("Order ID:" + order.OrderId);
                Console.WriteLine("Order Date:" + order.OrderDate);
                Console.WriteLine("Quantity:" + order.Quantity);
                Console.WriteLine("Discount:" + order.Discount);
                Console.WriteLine("Is Shipped:" + order.IsShipped);
               
            }
        }

        public static void CreateOrder()
        {
            db = new Assignment08DbEntities();

            Order order = new Order();
            Console.Write("Enter Order Id:");
           order.OrderId = int.Parse(Console.ReadLine());

            Console.Write("Enter Order Date:");
            order.OrderDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Quantity:");
            order.Quantity = short.Parse(Console.ReadLine());

            Console.Write("Enter Discount:");
            order.Discount = Double.Parse(Console.ReadLine());

            Console.Write("Enter is Shipped:");
            order.IsShipped = Boolean.Parse(Console.ReadLine());

            db.Orders.Add(order);
            db.SaveChanges();
            Console.WriteLine("Order Record Inserted");
        }

        public static void UpdateOrder()
        {
            db = new Assignment08DbEntities();
            Order order = new Order();
            Console.WriteLine("Enter Order ID to update the record");
            int id = int.Parse(Console.ReadLine());
            order = db.Orders.SingleOrDefault(e => e.OrderId == id);
            if (order == null)
            {
                Console.WriteLine($"NO such Record having ID {id} in the database ");
            }
            else
            {
                Console.Write("Enter new Order Date:");
                order.OrderId =int.Parse( Console.ReadLine());

                Console.Write("Enter Updated Quantity:");
                order.OrderDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter new Discount:");
                order.Quantity = short.Parse(Console.ReadLine());

                Console.Write("Enter Updated status of Is Shipped:");
                order.IsShipped = Boolean.Parse(Console.ReadLine());

                db.SaveChanges();
                Console.WriteLine("Order Record Updated Successfully!!!");
            }
        }
        public static void DeleteOrder()
        {
            db = new Assignment08DbEntities();
            Order order = new Order();
            Console.WriteLine("Enter Order ID to delete the record");
            int id = int.Parse(Console.ReadLine());
            order = db.Orders.SingleOrDefault(e => e.OrderId == id);
            if (order == null)
            {
                Console.WriteLine($"NO such Record having ID {id} in the database ");
            }
            else
            {
                db.Orders.Remove(order);
                db.SaveChanges();
                Console.WriteLine("Order Record Deleted Successfully!!!");
            }

        }
    }
}
