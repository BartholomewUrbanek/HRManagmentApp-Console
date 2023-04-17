

namespace HRManagmentApp
{
    public class ListOfEmployees
    {
        public Dictionary<Guid, Employee> employeeList;

        public ListOfEmployees(Dictionary<Guid, Employee> employeeList)
        {
            this.employeeList = employeeList;
        }

        internal void AddEmployee(Employee employee)
        {
            employeeList.Add(employee.Id, employee);
        }
        public Employee IsEmployeeListed(Employee newEmployee)
        {
            KeyValuePair<Guid, Employee> existingEmployee = employeeList.FirstOrDefault(x => x.Value.FirstName == newEmployee.FirstName
               && x.Value.LastName == newEmployee.LastName
               && x.Value.Position == newEmployee.Position
               && x.Value.EmploymentStatus == newEmployee.EmploymentStatus);
            return existingEmployee.Value;
        }
        public List<Employee> SearchEmployee(string searchedValue)
        {
            var matchingEmployees = employeeList.Where(kvp => kvp.Value.LastName == searchedValue
            || kvp.Value.Position.ToString() == searchedValue
            || kvp.Value.EmploymentStatus.ToString() == searchedValue)
                .OrderBy(kvp => kvp.Value.LastName)
                .Select(kvp => kvp.Value)
                .ToList();
            return matchingEmployees;
        }

        public void EditEmployee(string firstName, string lastName, Constants.Position position, Constants.EmploymentStatus employmentStatus, Guid guid)
        {
            Employee editedEmpolyee = EmployeeFactory.CreateEmployee(firstName, lastName, position, employmentStatus, guid);
            employeeList[guid] = editedEmpolyee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employeeList.Remove(employee.Id);
        }

        public List<Employee> AllEmployees()
        {
            List<Employee> employees = employeeList.Select(x => x.Value)
                .OrderBy(kvp => kvp.LastName)
                .ToList();
            return employees;
        }

 
    }
}
