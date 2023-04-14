namespace HRManagmentApp
{
    public class Controller
    {
        ListOfEmployees listOfEmployees;
        StringChecker stringChecker = new StringChecker();

        public Controller(ListOfEmployees listOfEmployees)
        {
            this.listOfEmployees = listOfEmployees;
        }

        public void MenuAddEmployee()
        {
            string firstName, lastName;
            Constants.Position position;
            Constants.EmploymentStatus employmentStatus;

            Console.WriteLine("\nEnter first name:");
            firstName = Console.ReadLine();
            while (!stringChecker.NameCheck(firstName) | firstName == String.Empty)
            {
                Console.WriteLine("First name should contain only letters and cannot be empty.Try again,please.");
                firstName = Console.ReadLine();
            }

            Console.WriteLine("\nEnter last name:");
            lastName = Console.ReadLine();
            while (!stringChecker.NameCheck(lastName) | lastName == String.Empty)
            {
                Console.WriteLine("Last name should contain only letters and cannot be empty.Try again,please.");
                lastName = Console.ReadLine();
            }

            Console.WriteLine("\nChoose position with index:\n");
            int counter = 1;
            foreach (Constants.Position positions in Enum.GetValues(typeof(Constants.Position)))
            {
                Console.WriteLine($"{counter}. {positions}");
                counter++;
            }

            positionCheck:
            ConsoleKeyInfo optionChosen = Console.ReadKey();
            switch (optionChosen.KeyChar)
            {
                case '1':
                    position = Constants.Position.EssentialEmployee;
                    break;
                case '2':
                    position = Constants.Position.Salesman;
                    break;
                case '3':
                    position = Constants.Position.Accountant;
                    break;
                case '4':
                    position = Constants.Position.Manager;
                    break;
                default:
                    Console.WriteLine("Invalid position, please choose correct one.");
                    goto positionCheck;
            }

            Console.WriteLine("\nChoose employment status with index:\n");
            counter = 1;
            foreach (Constants.EmploymentStatus employStatus in Enum.GetValues(typeof(Constants.EmploymentStatus)))
            {
                Console.WriteLine($"{counter}. {employStatus}");
                counter++;
            }

            employmentStatusCheck:
            optionChosen = Console.ReadKey();
            switch (optionChosen.KeyChar)
            {
                case '1':
                    employmentStatus = Constants.EmploymentStatus.FullTime;
                    break;
                case '2':
                    employmentStatus = Constants.EmploymentStatus.PartTime;
                    break;
                case '3':
                    employmentStatus = Constants.EmploymentStatus.Intern;
                    break;
                default:
                    Console.WriteLine("Invalid position, please choose correct one.");
                    goto employmentStatusCheck; 
            }

            Employee newEmployee = EmployeeFactory.CreateEmployee(firstName, lastName, position, employmentStatus);
            listOfEmployees.AddEmployee(newEmployee);
            Console.WriteLine("\nEmployee added to list:");
            Console.WriteLine(newEmployee.ToString());
        }

    }
}
