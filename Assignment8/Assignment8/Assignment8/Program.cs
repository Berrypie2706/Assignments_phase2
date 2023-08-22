using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8
{
    internal class Program
    {
        static Assignment08DbEntities db;
        static void Main(string[] args)
        {
            string a;
            do
            {


                try
                {
                    Console.WriteLine("Choose the Option");
                    Console.WriteLine("1. Create\n2. Read\n3. Update\n4. Delete");
                    int op = int.Parse(Console.ReadLine());

                    Console.WriteLine("Select the table");
                    Console.WriteLine("1. Employee\n2. Orders\n3. Products");
                    int op1 = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            {
                                switch (op1)
                                {
                                    case 1:
                                        {
                                            EmployeeClass.CreateEmployee();
                                            break;
                                        }
                                    case 2:
                                        {
                                            OrderClass.CreateOrder();
                                            break;

                                        }
                                    case 3:
                                        {
                                            ProductClass.CreateProduct();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Invalid Table");
                                            return;
                                        }

                                }
                                break;
                            }
                        case 2:
                            {
                                switch (op1)
                                {
                                    case 1:
                                        {
                                            EmployeeClass.ReadEmployee();
                                            break;
                                        }
                                    case 2:
                                        {
                                            OrderClass.ReadOrder();
                                            break;

                                        }
                                    case 3:
                                        {
                                            ProductClass.ReadProduct();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Invalid Table");
                                            return;
                                        }

                                }
                                break;
                            }
                        case 3:
                            {
                                switch (op1)
                                {
                                    case 1:
                                        {
                                            EmployeeClass.UpdateEmployee();
                                            break;
                                        }
                                    case 2:
                                        {
                                            OrderClass.UpdateOrder();
                                            break;

                                        }
                                    case 3:
                                        {
                                            ProductClass.UpdateProduct();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Invalid Table");
                                            return;
                                        }

                                }
                                break;
                            }
                        case 4:
                            {
                                switch (op1)
                                {
                                    case 1:
                                        {
                                            EmployeeClass.DeleteEmployee();
                                            break;
                                        }
                                    case 2:
                                        {
                                            OrderClass.DeleteOrder();
                                            break;

                                        }
                                    case 3:
                                        {
                                            ProductClass.DeleteProduct();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Invalid Table");
                                            return;
                                        }

                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Choose the valid operation");
                                return;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.ReadKey();
                }
                Console.WriteLine("Press Y to Continue*****");
                a = Console.ReadLine().ToLower();
            }

            while (a == "y");
        }
    }
}
            

        
    
