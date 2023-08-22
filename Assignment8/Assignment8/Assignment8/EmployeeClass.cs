using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8
{
    public class EmployeeClass
    {
        static Assignment08DbEntities db;
        public static void ReadEmployee()
        {
            db = new Assignment08DbEntities();
            foreach(Employee employee in db.Employees)
            {
                Console.WriteLine("Employee ID:"+ employee.EmployeeId);
                Console.WriteLine("First Name:"+ employee.FirstName);
                Console.WriteLine("Last Name:"+ employee.LastName);
                Console.WriteLine("Date Of Birth:"+ employee.BirthDate);
                Console.WriteLine("Salary:"+ employee.Salary);
                Console.WriteLine("");
            }
        }

        public static void CreateEmployee()
        {
            db = new Assignment08DbEntities();
            Employee employee = new Employee();
            Console.Write("Enter Employee Id:");
            employee.EmployeeId = int.Parse(Console.ReadLine());

            Console.Write("Enter First Name:");
            employee.FirstName = Console.ReadLine();

            Console.Write("Enter Last Name:");
            employee.LastName = Console.ReadLine();

            Console.Write("Enter Date Of Birth:");
            employee.BirthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Salary:");
            employee.Salary = decimal.Parse(Console.ReadLine());

            db.Employees.Add(employee);
            db.SaveChanges();
            Console.WriteLine("Employee Record Inserted");
        }

        public static void UpdateEmployee()
        {
            db = new Assignment08DbEntities();
            Employee employee = new Employee();
            Console.WriteLine("Enter employee ID to update the record");
            int id = int.Parse(Console.ReadLine());
            employee = db.Employees.SingleOrDefault(e=>e.EmployeeId == id);
            if(employee == null)
            {
                Console.WriteLine($"NO such Record having ID {id} in the database ");
            }
            else
            {
                Console.Write("Enter Updated First Name:");
                employee.FirstName = Console.ReadLine();

                Console.Write("Enter Updated Last Name:");
                employee.FirstName = Console.ReadLine();

                Console.Write("Enter Updated Date Of Birth:");
                employee.BirthDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Enter Updated Salary:");
                employee.Salary = decimal.Parse(Console.ReadLine());

                db.SaveChanges();
                Console.WriteLine("Employee Record Updated Successfully!!!");
            }
        }
        public static void DeleteEmployee()
        {
            db = new Assignment08DbEntities();
            Employee employee = new Employee();
            Console.WriteLine("Enter employee ID to delete the record");
            int id = int.Parse(Console.ReadLine());
            employee = db.Employees.SingleOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                Console.WriteLine($"NO such Record having ID {id} in the database ");
            }
            else
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
                Console.WriteLine("Employee Record Deleted Successfully!!!");
            }

        }
    }
}
