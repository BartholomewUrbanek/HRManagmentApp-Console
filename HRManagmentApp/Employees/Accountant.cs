using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagmentApp
{
    public class Accountant : Employee
    {
        private double _baseSalary = 6000;
        public Accountant(string firstName, string lastName, Constants.EmploymentStatus employmentStatus, Constants.Position position, Guid? guid = null) : base(firstName,lastName, position,guid)
        {
            this.EmploymentStatus = employmentStatus;
        }
        public override double CalculateSalary()
        {
            switch (EmploymentStatus)
            {
                case Constants.EmploymentStatus.FullTime:
                    return _baseSalary;
                case Constants.EmploymentStatus.PartTime:
                    return _baseSalary / 2;
                case Constants.EmploymentStatus.Intern:
                    return _baseSalary / 2 * 0.75;
                default:
                    throw new ArgumentException("Invalid employment status");
            }

        }
    }
}
