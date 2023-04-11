using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagmentApp
{
    public class EssentialEmployee: Employee
    {
        public EssentialEmployee(string firstName, string lastName, Constants.EmploymentStatus employmentStatus, Constants.Position position) : base(firstName, lastName, position)
        {
            this.EmploymentStatus = employmentStatus;
        }
        public override double CalculateSalary()
        {
            return 10.0;
        }
    }
}
