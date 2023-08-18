using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment6
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        static string sql = "server = DESKTOP-FG5F3C3;database = ProductInventoryDb;trusted_Connection = true;";
        static void Main(string[] args)
        {
            string c;
            do
            {
                try
                {
                    Console.WriteLine("Choose the operation");
                    Console.WriteLine("1.Read\n 2.Insert\n 3.Update\n 4.Remove");
                    int op = int.Parse(Console.ReadLine());

                    con = new SqlConnection(sql);

                    switch (op)
                    {
                        case 1:
                            {
                                con = new SqlConnection(sql);
                                con = new SqlConnection(sql);
                                cmd = new SqlCommand("select * from Products", con);
                                con.Open();
                                reader = cmd.ExecuteReader();
                                Console.WriteLine("Product ID\tProduct Name\tPrice\t\tQuantity\t\tMFGDate\t\tExpiry Date");
                                while (reader.Read())
                                {
                                    Console.Write(reader["Product_Id"] + "\t\t");
                                    Console.Write(reader["PName"] + " \t");
                                    Console.Write(reader["Price"] + "\t\t");
                                    Console.Write(reader["Quantity"] + "\t\t");
                                    Console.Write(reader["mfgdate"] + "\t");
                                    Console.Write(reader["expdate"]);
                                    Console.Write("\n");

                                }
                                break;
                            }
                        case 2:
                            {
                                con = new SqlConnection(sql);
                                cmd = new SqlCommand()
                                {

                                    CommandText = "insert into Products(Product_Id, PName, Price, Quantity, MfgDate, ExpDate)values(@id,@name,@price,@quantity,@mfdate,@exdate)",
                                    Connection = con

                                };
                                Console.WriteLine("Enter Product Id");
                                cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));

                                Console.WriteLine("Enter Product Name");
                                cmd.Parameters.AddWithValue("@name", Console.ReadLine());

                                Console.WriteLine("Enter Product Price");
                                cmd.Parameters.AddWithValue("@price", double.Parse(Console.ReadLine())); ;

                                Console.WriteLine("Enter Product Quantity");
                                cmd.Parameters.AddWithValue("@quantity", int.Parse(Console.ReadLine()));

                                Console.WriteLine("Enter Manufacturing Date");
                                cmd.Parameters.AddWithValue("@mfdate", DateTime.Parse(Console.ReadLine()));

                                Console.WriteLine("Enter Expiry Date");
                                cmd.Parameters.AddWithValue("@exdate", DateTime.Parse(Console.ReadLine()));
                                con.Open();

                                int nor = cmd.ExecuteNonQuery();
                                if (nor >= 1)
                                {
                                    Console.WriteLine("Product inserted!!!");
                                }
                                break;
                            }
                        case 3:
                            {
                                con = new SqlConnection(sql);
                                int id;
                                Console.WriteLine("Enter product id to update details");
                                id = int.Parse(Console.ReadLine());
                                cmd = new SqlCommand()
                                {
                                    CommandText = "select * from Products where Product_Id = @id",
                                    Connection = con
                                };
                                cmd.Parameters.AddWithValue("@id", id);
                                con.Open();
                                reader = cmd.ExecuteReader();
                                if (reader.HasRows)
                                {
                                    con.Close();
                                    con.Open();

                                    cmd = new SqlCommand()
                                    {

                                        CommandText = "update Products set Pname = @name, price = @price, quantity = @quantity, mfgdate = @mfd, expdate = @exdate where product_Id = @eid",
                                        Connection = con
                                    };
                                    Console.WriteLine("Enter new Product name");
                                    cmd.Parameters.AddWithValue("@name", Console.ReadLine());

                                    Console.WriteLine("Enter new Price ");
                                    cmd.Parameters.AddWithValue("@price", double.Parse(Console.ReadLine()));

                                    Console.WriteLine("Change product quantity");
                                    cmd.Parameters.AddWithValue("@quantity", Console.ReadLine());

                                    Console.WriteLine("Enter Manufacturing date ");
                                    cmd.Parameters.AddWithValue("@mfd", DateTime.Parse(Console.ReadLine()));

                                    Console.WriteLine("Enter Expiry date");
                                    cmd.Parameters.AddWithValue("@exdate", DateTime.Parse(Console.ReadLine()));

                                    cmd.Parameters.AddWithValue("eid", id);
                                    cmd.ExecuteNonQuery();
                                    Console.WriteLine("Product updated!!!");
                                }
                                else
                                {
                                    Console.WriteLine($"No such Product ID {id} exist in the database");
                                }
                                break;
                            }
                        case 4:
                            {
                                con = new SqlConnection(sql);

                                cmd = new SqlCommand()
                                {
                                    CommandText = "delete from Products where product_id = @id",
                                    Connection = con
                                };
                                Console.WriteLine("Enter the Product Id to delete the product");
                                cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
                                con.Open();
                                int nor = cmd.ExecuteNonQuery();
                                if (nor >= 1)
                                {
                                    Console.WriteLine("Product deleted!!!");
                                }
                                else
                                {
                                    Console.WriteLine($"No such product exists in the database");
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid choice");
                                return;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error!!!!" + e.Message);
                }
                finally
                {
                    con.Close();
                    Console.ReadKey();
                }
                Console.WriteLine("Press Y to to continue");
                c = Console.ReadLine();


            }
            while (c == "Y" || c == "y");


        }
    }
}
