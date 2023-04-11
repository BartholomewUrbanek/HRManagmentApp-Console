using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagmentApp
{
    public class Accountant : Employee
    {
        public Accountant(string firstName, string lastName, Constants.EmploymentStatus employmentStatus, Constants.Position position) : base(firstName,lastName, position)
        {
            this.EmploymentStatus = employmentStatus;
        }
        public override double CalculateSalary()
        {
            return 20.0;
        }


    }
}
