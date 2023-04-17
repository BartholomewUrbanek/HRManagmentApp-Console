namespace HRManagmentApp
{
    public class Controller
    {
        private string header = $"\u001b[32m{"",-5}{"First name",-25}{ "Last name",-25}{ "Position",-25}{ "Employment status",-25}{ "Salary"}\u001b[0m";

        ListOfEmployees listOfEmployees;
        StringChecker stringChecker = new StringChecker();

        public Controller(ListOfEmployees listOfEmployees)
        {
            this.listOfEmployees = listOfEmployees;
        }
        public int ChooseKey(int startIndex, int lastIndex)
        {
            int selectedIndex;
            ConsoleKeyInfo key = Console.ReadKey();
            while (!int.TryParse(key.KeyChar.ToString(), out selectedIndex)
                        || selectedIndex < startIndex
                        || selectedIndex > lastIndex)
            {
                Console.WriteLine("Incorrect choice, please select correct one with index.");
                key = Console.ReadKey();
            }
            return selectedIndex;
        }

        public Constants.Position Position()
        {
            Constants.Position position;

            Console.WriteLine("\nChoose position with index:\n");
            int counter = 1;
            foreach (Constants.Position positions in Enum.GetValues(typeof(Constants.Position)))
            {
                Console.WriteLine($"{counter}. {positions}");
                counter++;
            }
            int selectedIndex = ChooseKey(1, Enum.GetValues(typeof(Constants.Position)).Length + 1);
            switch (selectedIndex)
            {
                case 1:
                    return Constants.Position.EssentialEmployee;
                case 2:
                    return Constants.Position.Salesman;
                case 3:
                    return Constants.Position.Accountant;
                case 4:
                    return Constants.Position.Manager;
                default:
                    throw new ArgumentException("Invalid position");
            }
        }
        public Constants.EmploymentStatus EmploymentStatus()
        {
            Constants.EmploymentStatus status;
            Console.WriteLine("\nChoose employment status with index:\n");
            int counter = 1;
            foreach (Constants.EmploymentStatus employStatus in Enum.GetValues(typeof(Constants.EmploymentStatus)))
            {
                Console.WriteLine($"{counter}. {employStatus}");
                counter++;
            }
            int selectedIndex = ChooseKey(1, Enum.GetValues(typeof(Constants.EmploymentStatus)).Length + 1);
            switch (selectedIndex)
            {
                case 1:
                    return Constants.EmploymentStatus.FullTime;
                case 2:
                    return Constants.EmploymentStatus.PartTime;
                case 3:
                    return Constants.EmploymentStatus.Intern;
                default:
                    throw new ArgumentException("Invalid employment status");
            }
        }
        public Employee MenuAddEmployee()
        {
            string firstName, lastName;
            Constants.EmploymentStatus employmentStatus;
            Constants.Position position;

            Console.WriteLine("\nEnter first name:");
            firstName = stringChecker.NameCheck(Console.ReadLine());

            Console.WriteLine("\nEnter last name:");
            lastName = stringChecker.NameCheck(Console.ReadLine());

            position = Position();

            employmentStatus = EmploymentStatus();

            Employee newEmployee = EmployeeFactory.CreateEmployee(firstName, lastName, position, employmentStatus);
            Console.WriteLine("\n\nNew employee summary\n");
            Console.WriteLine(newEmployee.ToString());
            return newEmployee;
        }

        public void MenuManageEditEmployee(Employee selectedEmployee)
        {
            int editIndex = default(int);
            string firstName = selectedEmployee.FirstName;
            string lastName = selectedEmployee.LastName;
            Constants.Position position = selectedEmployee.Position;
            Constants.EmploymentStatus employmentStatus = selectedEmployee.EmploymentStatus;
            while (editIndex != 5)
            {
                Console.WriteLine("\n\nChoose what do you want to edit:" +
                "\n1.Edit first name." +
                "\n2.Edit last name." +
                "\n3.Edit position." +
                "\n4.Edit employment status." +
                "\n5.Abort changes." +
                "\n6.Save and exit.");

                editIndex = ChooseKey(1, 6);

                switch (editIndex)
                {
                    case 1:
                        Console.WriteLine("\nEnter first name:");
                        firstName = stringChecker.NameCheck(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("\nEnter last name:");
                        lastName = stringChecker.NameCheck(Console.ReadLine());
                        break;
                    case 3:
                        position = Position();
                        break;
                    case 4:
                        employmentStatus = EmploymentStatus();
                        break;
                    case 5:
                        return;
                    case 6:
                        listOfEmployees.EditEmployee(firstName, lastName, position, employmentStatus, selectedEmployee.Id);
                        editIndex -= 1;
                        break;
                    default:
                        break;
                }
            }
        }

        public void MenuManageEmployees()
        {
            Console.WriteLine("\nInput employee last name (note that it is case-sensitive)");
            string lastName = stringChecker.NameCheck(Console.ReadLine());
            var employeesFound = listOfEmployees.SearchEmployee(lastName);
            if (employeesFound.Count < 1)
            {
                Console.WriteLine("\n\nThere are no employees matching the given criteria.");
                return;
            }
            Console.WriteLine("\n\nList of employees matching criteria:\n");
            Console.WriteLine(header);
            int counter = 1;
            foreach (Employee employee in employeesFound) 
            {
                Console.WriteLine($"{counter,-4} {employee.ToString()}");
                counter++;
            }
            Console.WriteLine("\nWhich employee you want to edit/delete?");
            int selectedIndex = ChooseKey(1, employeesFound.Count());
            Employee selectedEmployee = employeesFound[selectedIndex - 1];


            Console.WriteLine("\n\nChoose action:" +
                "\n1.Edit employee data." +
                "\n2.Delete employee." +
                "\n3.Abort.");
            selectedIndex = ChooseKey(1, 3);

            switch (selectedIndex)
            {
                case 1:
                    MenuManageEditEmployee(selectedEmployee);
                    break;
                case 2:
                    listOfEmployees.DeleteEmployee(selectedEmployee);
                    break;
                case 3:
                    return;
                default:
                    break;

            }
        }

        public void MenuTryAddEmployee()
        {
            Employee newEmployee = MenuAddEmployee();
            if (listOfEmployees.IsEmployeeListed(newEmployee) != null)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n\nAdding new employee failed, employee is already in the list:");
                Console.ResetColor();
                newEmployee.ToString();
                return;
            }
            listOfEmployees.AddEmployee(newEmployee);

        }

        public void MenuSearchEmployee()
        {
            Console.WriteLine("\n\nChoose search method:" +
                "\n1.Search by last name." +
                "\n2.Search by position." +
                "\n3.Search by employment status." +
                "\n4.Display all employees." +
                "\n5.Abort.");

            int selectedIndex = ChooseKey(1, 5);
            List<Employee> matchingEmployees = new List<Employee>();
            switch (selectedIndex)
            {
                case 1:
                    Console.WriteLine("\n\nInput employee last name (note that it is case-sensitive)\n");
                    string lastName = stringChecker.NameCheck(Console.ReadLine());
                    matchingEmployees = listOfEmployees.SearchEmployee(lastName);
                    break;
                case 2:
                    Constants.Position position = Position();
                    matchingEmployees = listOfEmployees.SearchEmployee(position.ToString());
                    break;
                case 3:
                    Constants.EmploymentStatus employmentStatus = EmploymentStatus();
                    matchingEmployees = listOfEmployees.SearchEmployee(employmentStatus.ToString());
                    break;
                case 4:
                    matchingEmployees = listOfEmployees.AllEmployees();
                    break;
                case 5:
                    return;
                default:
                    break;
            }

            if(matchingEmployees.Count < 1)
            {
                Console.WriteLine("\n\nThere are no employees matching the given criteria.");
                return;
            }

            Console.WriteLine("\n\nList of employees matching criteria:\n");
            Console.WriteLine(header);
            int counter = 1;
            foreach (Employee employee in matchingEmployees)
            {
                Console.WriteLine($"{counter,-4} {employee.ToString()}");
                counter++;
            }

        }

        public void MenuFinancialRaport()
        {
            List<Employee> employees = listOfEmployees.AllEmployees();

            double essentialSalary = employees.Where(employee => employee.Position == Constants.Position.EssentialEmployee)
                .Sum(employee => employee.CalculateSalary());

            double salesmanSalary = employees.Where(employee => employee.Position == Constants.Position.Salesman)
                .Sum(employee => employee.CalculateSalary());
            
            double accountantSalary = employees.Where(employee => employee.Position == Constants.Position.Accountant)
                .Sum(employee => employee.CalculateSalary());

            double managerSalary = employees.Where(employee => employee.Position == Constants.Position.Manager)
                .Sum(employee => employee.CalculateSalary());

            double totalSalary = employees.Sum(employee => employee.CalculateSalary());

            Console.WriteLine("Sum of salaries of all employees:\n");
            Console.WriteLine($"\u001b[32m{"Essential employee",-25}{"Salesman",-25}{"Accountant",-25}" +
                $"{"Manager",-25}{"Total sum"}\u001b[0m");
            Console.WriteLine($"{essentialSalary,-25}{salesmanSalary,-25}{accountantSalary,-25}" +
                $"{managerSalary,-25}{totalSalary,-25}");
        }
    }

}

