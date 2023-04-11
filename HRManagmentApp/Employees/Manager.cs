using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagmentApp
{
    internal class Manager : Employee, ISalary
    {
        public Manager(string firstName, string lastName, Constants.EmploymentStatus employmentStatus, Constants.Position position) : base(firstName, lastName,position)
        {
            this.EmploymentStatus = employmentStatus;
        }

        public override double CalculateSalary()
        {
            return 50.0;
        }
        
    }
}
