using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace A4_BrandonArgenalAlmanza
{
    internal class Program
    {
        static List<Employee> Employees = Employee.EmployeeList;
        static void Main(string[] args)
        {
            Console.WriteLine("Brandon Argenal Almanza - 301467830");
            TestLINQ();
        }
        static void TestLINQ()
        {
            Console.WriteLine("Displaying all employees in INCREASING ORDER by NAMES");
            var r1 = from employ in Employees
                     orderby employ.Name ascending
                     select employ;
            Console.WriteLine($"{string.Join("\n", r1)}");


            Console.WriteLine($"\nDisplaying all employees who are MANAGERS");
            var r2 = from employ in Employees
                     where employ.IsManager == true
                     select employ;
            Console.WriteLine($"{string.Join("\n", r2)}");


            Console.WriteLine("\nDisplaying all employees in HUMAN RESOURCES in INCREASING ORDER of EmployeeID.");
            var r3 = from employ in Employees
                     where employ.Department == "Human Resources"
                     orderby employ.EmployeeID ascending
                     select employ;
            Console.WriteLine($"{string.Join("\n", r3)}");


            Console.WriteLine("\nDisplaying all employees hired AFTER 2020.");
            var r4 = Employees.Where(employ => employ.hireYear > 2020);
            Console.WriteLine($"{string.Join("\n", r4)}");


            Console.WriteLine("\nDisplaying the employee who is MANAGER in IT DEPT");
            var r5 = Employees.Where(employ => employ.Department == "IT" && employ.IsManager == true);
            Console.WriteLine($"{string.Join("\n", r5)}");


            Console.WriteLine($"\nDisplaying all employees who are OPERATORS sorted by DEPT NAME");
            var r6 = from employ in Employees
                     where employ.Designation.Contains("Operator")
                     orderby employ.Department
                     select employ;
            Console.WriteLine($"{string.Join("\n", r6)}");


            Console.WriteLine($"\nDisplaying all employees grouped by DEPARTMENTS");
            var r7 = Employees.GroupBy(employ => employ.Department);
            
            foreach ( var group in r7)
            {
                Console.WriteLine($"\n{group.Count()} employees in {group.Key}");
                Console.WriteLine($"{string.Join("\n", group)}");
            }
                
        }
    }
}
