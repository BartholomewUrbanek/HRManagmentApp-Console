

namespace HRManagmentApp
{
    public class ListOfEmployees
    {
        public Dictionary<Guid, Employee> EmployeeList;

        public ListOfEmployees(Dictionary<Guid, Employee> employeeList)
        {
            this.EmployeeList = employeeList;
        }

        public void AddEmployee(Employee newEmployee)
        {
            KeyValuePair<Guid, Employee> existingEmployee = EmployeeList.FirstOrDefault(x => x.Value.FirstName == newEmployee.FirstName
               && x.Value.LastName == newEmployee.LastName
               && x.Value.Position == newEmployee.Position
               && x.Value.EmploymentStatus == newEmployee.EmploymentStatus);

            if (existingEmployee.Value != null)
            {
                Console.WriteLine($"\n Employee already in the list");
                Console.WriteLine($"\n {existingEmployee.Key}" +
                  $"\t{existingEmployee.Value.FirstName}" +
                  $"\t{existingEmployee.Value.LastName}");
            }
                EmployeeList.Add(newEmployee.Id, newEmployee);

        }

        public List<KeyValuePair<Guid, Employee>> SearchEmployee(string lastName)
        {
            var matchingKeys = EmployeeList.Where(kvp => kvp.Value.LastName == lastName).ToList();

            Console.WriteLine("\nList of employees matching criteria:\n");
            int counter = 1;
            foreach (KeyValuePair<Guid, Employee> kvp in EmployeeList)
            {
                Console.WriteLine($"{counter}\t{kvp.Value.FirstName}\t" +
                    $"{kvp.Value.LastName}\t" +
                    $"{kvp.Value.Position}\t" +
                    $"{kvp.Value.EmploymentStatus}");
                counter++;
            }
            return matchingKeys;
        }

        public void EditEmployee(string lastName)
        {
            SearchEmployee(lastName);
            Console.WriteLine("Which employee you want to edit?");



        }
    }
}
