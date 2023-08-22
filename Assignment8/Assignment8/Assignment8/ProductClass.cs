using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8
{
    public class ProductClass
    {
        static Assignment08DbEntities db;
        public static void CreateProduct()
        {
            db = new Assignment08DbEntities();
            Product product = new Product();
            Console.WriteLine("Enter Product ID");
            product.ProductId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Product Name");
            product.ProductName = Console.ReadLine();

            Console.WriteLine("Enter Product Description");
            product.Description = Console.ReadLine();

            Console.WriteLine("Enter Product Price");
            product.Price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter Product Release Date");
            product.ReleaseDate = DateTime.Parse(Console.ReadLine());

            db.Products.Add(product);
            db.SaveChanges();
            Console.WriteLine("Product created successfully!!!");
        }

        public static void ReadProduct()
        {
            db = new Assignment08DbEntities();
            foreach (Product product in db.Products)
            {
                Console.WriteLine("Product ID:" + product.ProductId);
                Console.WriteLine("Product Name:" + product.ProductName);
                Console.WriteLine("Description:" + product.Description);
                Console.WriteLine("Price:" + product.Price);
                Console.WriteLine("Release Date:" + product.ReleaseDate);
                Console.WriteLine("");
            }

        }
        public static void UpdateProduct()
        {
            db = new Assignment08DbEntities();
            Product product = new Product();
            Console.WriteLine("Enter Product Id to update the product details");
            int id = int.Parse(Console.ReadLine());
            product = db.Products.SingleOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                Console.WriteLine($"No such Product ID {id} available in the database");
            }
            else
            {
                Console.WriteLine("Enter New Product Name");
                product.ProductName = Console.ReadLine();


                Console.WriteLine("Enter New Product Description");
                product.Description = Console.ReadLine();


                Console.WriteLine("Enter New Product Price");
                product.Price = decimal.Parse(Console.ReadLine());


                Console.WriteLine("Enter New Product Release date");
                product.ReleaseDate = DateTime.Parse(Console.ReadLine());
                db.SaveChanges();
                Console.WriteLine("Product Record Updated Successfully!!!");
            }
        }
        public static void DeleteProduct()
        {
            db = new Assignment08DbEntities();
            Product product = new Product();
            Console.WriteLine("Enter Product Id to Delete the product record");
            int id = int.Parse(Console.ReadLine());
            product = db.Products.SingleOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                Console.WriteLine($"No such Product ID {id} available in the database");
            }
            else
            {
                db.Products.Remove(product);
                db.SaveChanges();
                Console.WriteLine("Product Deleted Successfully!!!");
            }
        }
    }
}
