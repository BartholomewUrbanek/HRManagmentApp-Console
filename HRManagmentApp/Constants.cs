using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagmentApp
{
    public static class Constants
    {
        public enum EmploymentStatus
        {
            FullTime,
            PartTime,
            Contract,
            Intern
        }

        public enum Position
        {
            EssentialEmployee,
            Accountant,
            Salesman,
            Manager
        }
    }
}
