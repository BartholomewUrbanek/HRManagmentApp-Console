using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace HRManagmentApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Guid,Employee> employees = new Dictionary<Guid,Employee>();
            ListOfEmployees test = new ListOfEmployees(employees);
            Employee employee1 = EmployeeFactory.CreateEmployee("Mariusz", "Kowalski", Constants.Position.Accountant, Constants.EmploymentStatus.FullTime);
            Employee employee2 = EmployeeFactory.CreateEmployee("Mariusz", "Kowalski", Constants.Position.Accountant, Constants.EmploymentStatus.FullTime);


            test.AddEmployee(employee1);
            test.AddEmployee(employee2);
            


            test.SearchEmployee("Kowalski");

            Regex regex = new Regex("^[a-zA-Z]{3,}$");
            bool isMatch = regex.IsMatch("Ja1n");
            Console.WriteLine(isMatch);

            Controller controller = new Controller(test);
            string name1 = "k11";
            controller.MenuAddEmployee();
            Console.ReadKey();

        }
    }
}
