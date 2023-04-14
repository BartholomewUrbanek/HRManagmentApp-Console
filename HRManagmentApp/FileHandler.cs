namespace HRManagmentApp
{
    public class FileHandler
    {
        public Dictionary<Guid, Employee> ReadFile(string filePatch)
        {
            Dictionary<Guid, Employee> employeeList = new Dictionary<Guid, Employee>();

            if (!File.Exists(filePatch)) return employeeList;

            StreamReader fileReader = new StreamReader(filePatch);

            while (!fileReader.EndOfStream)
            {
                Employee newEmployee = EmployeeFactory.CreateEmployee(String.Empty, String.Empty, Constants.Position.EssentialEmployee, Constants.EmploymentStatus.FullTime);

                string header = fileReader.ReadLine();
                var lines = header.Split(',');
                newEmployee.Id = Guid.Parse(lines[0]);
                newEmployee.FirstName = lines[1];
                newEmployee.LastName = lines[2];
                newEmployee.Position = Enum.Parse<Constants.Position>(lines[3]);
                newEmployee.EmploymentStatus = Enum.Parse<Constants.EmploymentStatus>(lines[4]);
                employeeList.Add(newEmployee.Id, newEmployee);  
            }
            fileReader.Close();
            return employeeList;
        }

        public void SaveFile(string filePatch, Dictionary<Guid,Employee> employeeList)
        {
            StreamWriter saveDictionaryToFile = new StreamWriter(filePatch, false);
            foreach (KeyValuePair<Guid,Employee> entry in employeeList)
            {
                string lineToSave = ($"{ entry.Key},{entry.Value.FirstName},{entry.Value.LastName},{entry.Value.Position}, {entry.Value.EmploymentStatus}");
                {
                    saveDictionaryToFile.WriteLine(lineToSave);
                }
            }
            saveDictionaryToFile.Close();
        }
    }
}
