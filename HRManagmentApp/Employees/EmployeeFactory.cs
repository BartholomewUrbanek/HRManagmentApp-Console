using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagmentApp
{
    public  static class EmployeeFactory
    {
        public static Employee CreateEmployee(string firstName, string lastName, Constants.Position position, Constants.EmploymentStatus employmentStatus, Guid? guid = null )
        {
            switch (position)
            {
                case Constants.Position.EssentialEmployee:
                    return new EssentialEmployee(firstName, lastName, employmentStatus,position);
                case Constants.Position.Salesman:
                    return new Salesman(firstName, lastName, employmentStatus, position);
                case Constants.Position.Accountant:
                    return new Accountant(firstName, lastName, employmentStatus,position);
                case Constants.Position.Manager:
                    return new Manager(firstName, lastName, employmentStatus,position);
                default:
                    throw new ArgumentException("Invalid position");
            }
        }
    }
}
