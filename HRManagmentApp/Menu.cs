using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagmentApp
{
    internal class Menu
    {
        public void MenuDisplay()
        {
            string currentDir = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDir,"employeeList.csv");
            FileHandler fileHandler = new FileHandler();
            Dictionary<Guid, Employee> employees = fileHandler.ReadFile(filePath);
            ListOfEmployees listOfEmployees = new ListOfEmployees(employees);
            Controller controller = new Controller(listOfEmployees);
            DisplayLogo();

            int selectedIndex = default(int);

            while (selectedIndex != 6)
            {
                Console.WriteLine(
                    "\n1. Add new employee." +
                    "\n2. Edit/delete existing employee." +
                    "\n3. Search for employee" +
                    "\n4. Display financial raport." +
                    "\n5. Save and exit." +
                    "\n6. Exit without saving."
                    );
                selectedIndex = controller.ChooseKey(1, 6);
                switch (selectedIndex)
                {
                    case 1:
                        Console.Clear();
                        DisplayLogo();
                        listOfEmployees.AddEmployee(controller.MenuAddEmployee());
                        break;
                    case 2:
                        Console.Clear();
                        DisplayLogo();
                        controller.MenuManageEmployees();
                        break;
                    case 3:
                        Console.Clear();
                        DisplayLogo();
                        controller.MenuSearchEmployee();
                        break;
                    case 4:
                        Console.Clear();
                        DisplayLogo();
                        controller.MenuFinancialRaport();
                        break;
                    case 5:                   
                        Console.Clear();
                        DisplayLogo();
                        fileHandler.SaveFile(filePath, employees);
                        return;
                    case 6:
                        return;
                    default:
                        return;

                }


            }

        }
        private void DisplayLogo()
        {
            Console.WriteLine(@" _    _ _____    __  __                                              _  ");
            Console.WriteLine(@"| |  | |  __ \  |  \/  |                                            | |  ");
            Console.WriteLine(@"| |__| | |__) | | \  / | __ _ _ __   __ _  __ _ _ __ ___   ___ _ __ | |_ ");
            Console.WriteLine(@"|  __  |  _  /  | |\/| |/ _` | '_ \ / _` |/ _` | '_ ` _ \ / _ \ '_ \| __|");
            Console.WriteLine(@"| |  | | | \ \  | |  | | (_| | | | | (_| | (_| | | | | | |  __/ | | | |_ ");
            Console.WriteLine(@"|_|  |_|_|  \_\ |_|  |_|\__,_|_| |_|\__,_|\__, |_| |_| |_|\___|_| |_|\__|");
            Console.WriteLine(@"                                           __/ |                         ");
            Console.WriteLine(@"                                          |___/                         ");
        }
        
    }
}
