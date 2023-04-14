using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HRManagmentApp
{
    internal class StringChecker
    {
        const string NamePattern = "^[a-zA-Z]{3,}$";

        public bool NameCheck(string name)
        {
            return Regex.IsMatch(name, NamePattern);
        }
        
    }
}
