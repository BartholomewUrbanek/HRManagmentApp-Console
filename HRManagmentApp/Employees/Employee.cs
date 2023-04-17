using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagmentApp
{
    public abstract class Employee : ISalary
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Constants.Position Position { get; set; }
        public Constants.EmploymentStatus EmploymentStatus { get; set; }


        protected Employee(string firstName, string lastName, Constants.Position position, Guid? guid = null)
        {
            this.Id = guid ?? Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Position = position;
        }
        public abstract double CalculateSalary();

        public override string ToString()
        {
            //return $"{FirstName}" +
            //    $"\t\t{LastName}" +
            //    $"\t\t{Position}" +
            //    $"\t\t{EmploymentStatus}" +
            //    $"\t{CalculateSalary()}";

           return $"{FirstName,-25}{LastName,-25}{Position,-25}{EmploymentStatus,-25}{CalculateSalary()}";

        }
    }
}
