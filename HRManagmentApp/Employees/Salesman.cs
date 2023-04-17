using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagmentApp
{
    public class Salesman : Employee
    {
        private const double _salesCommision = 0.05; // Constants used for MVP purposes
        private const double _baseSalary = 4500.0;
        private const double _salesStandard = 10000; // Constants used for MVP purposes
        private double salesThisMonth { get; set; }
        public Salesman(string firstName, string lastName, Constants.EmploymentStatus employmentStatus, Constants.Position position, Guid? guid = null) : base(firstName, lastName, position, guid)
        {
            this.EmploymentStatus = employmentStatus;
        }
        public override double CalculateSalary()
        {
            switch (EmploymentStatus)
            {
                case Constants.EmploymentStatus.FullTime:
                    return _baseSalary + _salesStandard * _salesCommision;
                case Constants.EmploymentStatus.PartTime:
                    return _baseSalary / 2 * _salesStandard * _salesCommision;
                case Constants.EmploymentStatus.Intern:
                    return _baseSalary / 2 * (_salesStandard * (_salesCommision / 2));
                default:
                    throw new ArgumentException("Invalid employment status");
            }
        }
    }
}
