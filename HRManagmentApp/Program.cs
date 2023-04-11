using System;

namespace HRManagmentApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = EmployeeFactory.CreateEmployee(Constants.Position.Accountant, "Jan", "Kowalski",Constants.EmploymentStatus.FullTime );
            Employee employee2 = EmployeeFactory.CreateEmployee(Constants.Position.Manager, "Mariusz", "Kowalski", Constants.EmploymentStatus.PartTime);
            Employee employee3 = EmployeeFactory.CreateEmployee(Constants.Position.EssentialEmployee, "Krzysztof", "Kowalski", Constants.EmploymentStatus.Intern);


            Employee[] employees = new Employee[] { employee1, employee2, employee3 };

            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine(employees[i].CalculateSalary());
            }
        }
    }
}
