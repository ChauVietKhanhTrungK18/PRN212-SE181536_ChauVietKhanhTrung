using BusinessLayer.IService;
using BusinessObjects;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public bool AuthenticateEmployee(string userName, string password)
        {
            var employee = _employeeRepository.GetEmployeeByUserName(userName);
            return employee != null && employee.Password == password;
        }

        public Employee GetEmployeeByUserName(string userName)
        {
            return _employeeRepository.GetEmployeeByUserName(userName);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
        }

        public void UpdateEmployee(int employeeId, string newJobTitle)
        {
            _employeeRepository.UpdateEmployee(employeeId, newJobTitle);
        }

        public void DeleteEmployee(int employeeId)
        {
            _employeeRepository.DeleteEmployee(employeeId);
        }

        public List<Employee> SearchEmployeeByName(string name)
        {
            return _employeeRepository.SearchEmployeeByName(name);
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _employeeRepository.GetEmployeeById(employeeId);
        }
    }

}
