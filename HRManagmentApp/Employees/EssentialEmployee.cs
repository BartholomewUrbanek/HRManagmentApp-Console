using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagmentApp
{
    public class EssentialEmployee: Employee
    {
        private const double _hourlyRate = 22.5;
        private const int _workingDays = 20; // Constants used for MVP purposes
        private const int _fullTimeHours = 8;
        public EssentialEmployee(string firstName, string lastName, Constants.EmploymentStatus employmentStatus, Constants.Position position, Guid? guid = null) : base(firstName, lastName, position,guid)
        {
            this.EmploymentStatus = employmentStatus;
        }
        public override double CalculateSalary()
        {
            switch (EmploymentStatus)
            {
                case Constants.EmploymentStatus.FullTime:
                    return _hourlyRate * _workingDays * _fullTimeHours;
                case Constants.EmploymentStatus.PartTime:
                    return _hourlyRate * _workingDays * _fullTimeHours/2;
                case Constants.EmploymentStatus.Intern:
                    return (_hourlyRate*0.75)  * _workingDays * _fullTimeHours/2;
                default:
                    throw new ArgumentException("Invalid employment status");
            }
        }
    }
}
