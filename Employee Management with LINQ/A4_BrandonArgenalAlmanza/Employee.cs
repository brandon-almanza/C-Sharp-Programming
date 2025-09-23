using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4_BrandonArgenalAlmanza
{
    public class Employee
    {
        public int EmployeeID { get; }
        public string Name { get; }
        public string Designation { get; }
        public bool IsManager { get; }
        public int hireYear { get; }
        public string Department { get; }

        public Employee(int id, string name, string designation, bool mgr, int year, string department)
        {
            this.EmployeeID = id;
            this.Name = name;
            this.Designation = designation;
            this.IsManager = mgr;
            this.hireYear = year;
            this.Department = department;
        }

        public static List<Employee> EmployeeList = new List<Employee>
            {
                new Employee(111, "Pail Willingam", "General Manager", true, 2000, "IT"),
                new Employee(112, "Alanah Stanning", "Food Chemist", false, 2021, "Sales"),
                new Employee(123, "Tate Slides", "Help Desk Operator", false, 2019, "Accounts"),
                new Employee(114, "Edna Skerratt", "Chief Design Engineer", false,2022,  "Manufacturer"),
                new Employee(245, "Ulrick Costelloe", "Geologist IV", false, 2015, "Manufacturer"),
                new Employee(616, "Mollie Pfeuffer", "Environmental Tech", false, 2014, "Accounts"),
                new Employee(193, "Son Croser", "Engineer III", false, 2021, "Manufacturer"),
                new Employee(3241,"Noemi Appleby", "Health Coach II", true, 2017,"Accounts"),
                new Employee(2719, "Upton Mander", "Food Chemist", false, 2018, "Human Resources"),
                new Employee(618, "Delano Shieldon", "Civil Engineer", false, 2018, "Sales"),
                new Employee(819, "Andres Ioselev", "Environmental Tech", false, 2018, "Human Resources"),
                new Employee(172, "Art Warkup", "VP Accounting", true, 2007, "Sales"),
                new Employee(883, "Gusta Elt", "GIS Operator", false, 2001, "IT")
            };

        public override string ToString()
        {
            return $"{this.EmployeeID} --- {this.Name} --- {this.Designation} --- {this.hireYear} --- {(this.IsManager ? "Manager ---" : "")} {this.Department}";
        }
    }
}
