using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagmentApp
{
    public class Manager : Employee, ISalary
    {
        private const double _baseSalary = 7500;
        private const double _bonus = 0.10; // Constants used for MVP purposes
        public Manager(string firstName, string lastName, Constants.EmploymentStatus employmentStatus, Constants.Position position, Guid? guid = null) : base(firstName, lastName,position,guid)
        {
            this.EmploymentStatus = employmentStatus;
        }

        public override double CalculateSalary()
        {
            switch (EmploymentStatus)
            {
                case Constants.EmploymentStatus.FullTime:
                    return _baseSalary + (_baseSalary*_bonus);
                case Constants.EmploymentStatus.PartTime:
                    return _baseSalary / 2 + (_baseSalary*_bonus);
                case Constants.EmploymentStatus.Intern:
                    return _baseSalary / 2 * 0.65;
                default:
                    throw new ArgumentException("Invalid employment status");
            }
        }
        
    }
}
