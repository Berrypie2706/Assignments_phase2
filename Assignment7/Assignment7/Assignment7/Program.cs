using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Assignment7
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter adapter;
        static DataSet ds;
        static string conString = "server = DESKTOP-FG5F3C3 ; database = Assignment07Db; trusted_connection = true;";
        static void Main(string[] args)
        {
            string ni;
            do
            {
                try
                {

                    con = new SqlConnection(conString);
                    cmd = new SqlCommand("select * from Book", con);
                    adapter = new SqlDataAdapter(cmd);
                    ds = new DataSet();
                    adapter.Fill(ds);
                    con.Open();
                    DataTable dt = ds.Tables[0];
                    DataRow dr = dt.NewRow();

                    Console.WriteLine("Choose the Opeartion");
                    Console.WriteLine("1. Display\n2. Add Book\n3. Update Book Quantity ");
                    int op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            {

                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    Console.WriteLine("Book Id: " + ds.Tables[0].Rows[i]["BookId"]);
                                    Console.WriteLine("Title: " + ds.Tables[0].Rows[i]["Title"]);
                                    Console.WriteLine("Author: " + ds.Tables[0].Rows[i]["Author"]);
                                    Console.WriteLine("Genre: " + ds.Tables[0].Rows[i]["Genre"]);
                                    Console.WriteLine("Quantity: " + ds.Tables[0].Rows[i]["Quantity"]);
                                }
                                break;
                            }
                        case 2:
                            {
                                Console.Write("Enter Book Id:");
                                dr["BookId"] = int.Parse(Console.ReadLine());

                                Console.Write("Enter Title:");
                                dr["Title"] = Console.ReadLine();

                                Console.Write("Enter Author Name:");
                                dr["Author"] = Console.ReadLine();

                                Console.Write("Enter Book Genre:");
                                dr["Genre"] = Console.ReadLine();

                                Console.Write("Enter Quantity:");
                                dr["Quantity"] = int.Parse(Console.ReadLine());

                                dt.Rows.Add(dr);
                                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);

                                adapter.Update(ds);
                                Console.WriteLine("Inserted Successfully!!!");

                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Enter Book Title to update the Book Quantity");
                                string bt = Console.ReadLine();
                                dr = null;
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (dt.Rows[i]["Title"].ToString() == bt)
                                    {
                                        dr = dt.Rows[i];
                                        break;
                                    }
                                }
                                if (dr != null)
                                { 

                                    Console.Write("Enter Updated Quantity:");
                                    dr["Quantity"] = int.Parse(Console.ReadLine());

                                    SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
                                    adapter.Update(ds);
                                    Console.WriteLine("Quantity Updated Successfully!!!");
                                }
                                else
                                {
                                    Console.WriteLine("No such Data Exists in the database");
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid Operation!!!\nTry Again");
                                return;
                            }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Errror!!!" + ex.Message);
                }
                finally
                {
                    Console.WriteLine("End of Program!!!");
                    con.Close();
                    Console.ReadKey();
                }
                Console.WriteLine("Press Y to Continue Or Press Any Key To Exit");
                ni = Console.ReadLine().ToLower();
            }
            while (ni == "y");

            }
    }
}
