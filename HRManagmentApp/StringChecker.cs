using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;


namespace HRManagmentApp
{
    internal class StringChecker
    {
        const string NamePattern = "^[a-zA-Z]{3,}$";

        public string NameCheck(string name)
        {
            while (!Regex.IsMatch(name, NamePattern) && name == String.Empty)
            {
                Console.WriteLine("Value cannot be empty and must contain only letters (minimum 3).");
                name = Console.ReadLine();
            }
            return name;
        }
    }

}
