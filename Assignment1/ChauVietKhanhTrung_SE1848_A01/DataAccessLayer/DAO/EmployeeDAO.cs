using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class EmployeeDAO
    {
        private List<Employee> _employees;
        public EmployeeDAO()
        {
            _employees = new List<Employee>
            {
                new Employee { EmployeeID = 1, Name = "Alice Johnson", UserName = "alice123", Password = "password", JobTitle = "Manager", Birthday = new DateTime(1985, 5, 15), Address = "123 Main St" },
                new Employee { EmployeeID = 2, Name = "Bob Smith", UserName = "bob456", Password = "password", JobTitle = "Sales", Birthday = new DateTime(1990, 8, 20), Address = "456 Oak Ave" },
                new Employee { EmployeeID = 3, Name = "Charlie Brown", UserName = "charlie789", Password = "password", JobTitle = "IT Support", Birthday = new DateTime(1987, 3, 10), Address = "789 Pine Rd" },
                new Employee { EmployeeID = 4, Name = "David Clark", UserName = "david101", Password = "password", JobTitle = "Accountant", Birthday = new DateTime(1992, 11, 5), Address = "321 Maple Dr" },
                new Employee { EmployeeID = 5, Name = "Eva Green", UserName = "eva202", Password = "password", JobTitle = "Marketing", Birthday = new DateTime(1993, 7, 22), Address = "654 Birch Ln" },
                new Employee { EmployeeID = 6, Name = "Frank Harris", UserName = "frank303", Password = "password", JobTitle = "HR", Birthday = new DateTime(1986, 9, 18), Address = "987 Cedar Blvd" },
                new Employee { EmployeeID = 7, Name = "Grace Lee", UserName = "grace404", Password = "password", JobTitle = "Developer", Birthday = new DateTime(1991, 12, 11), Address = "123 Spruce St" },
                new Employee { EmployeeID = 8, Name = "Henry Moore", UserName = "henry505", Password = "password", JobTitle = "Designer", Birthday = new DateTime(1994, 1, 30), Address = "567 Elm Ave" },
                new Employee { EmployeeID = 9, Name = "Ivy King", UserName = "ivy606", Password = "password", JobTitle = "Assistant", Birthday = new DateTime(1989, 4, 10), Address = "123 Willow Ln" },
                new Employee { EmployeeID = 10, Name = "Jack White", UserName = "jack707", Password = "password", JobTitle = "Support", Birthday = new DateTime(1995, 6, 25), Address = "789 Fir St" }
            };
        }
        public Employee GetEmployeeByUserName(string userName)
        {
            return _employees.FirstOrDefault(e => e.UserName == userName);
        }
        public void AddEmployee(Employee employee) => _employees.Add(employee);
        public List<Employee> GetAllEmployees() => _employees;
        public Employee GetEmployeeById(int employeeId) => _employees.FirstOrDefault(e => e.EmployeeID == employeeId);
        public void UpdateEmployee(int employeeId, string newJobTitle)
        {
            var employee = _employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            if (employee != null) employee.JobTitle = newJobTitle;
        }
        public void DeleteEmployee(int employeeId)
        {
            var employee = _employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            if (employee != null) _employees.Remove(employee);
        }
        public List<Employee> SearchEmployeeByName(string name) =>
            _employees.Where(e => e.Name.Contains(name)).ToList();
         }

    }
