using BusinessObjects;
using DataAccessLayer.DAO;
using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDAO _employeeDAO;

        public EmployeeRepository()
        {
            _employeeDAO = new EmployeeDAO(); 
        }

        public Employee GetEmployeeByUserName(string userName)
        {
            return _employeeDAO.GetEmployeeByUserName(userName);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeDAO.GetAllEmployees();
        }

        public void AddEmployee(Employee employee)
        {
            _employeeDAO.AddEmployee(employee);
        }

        public void UpdateEmployee(int employeeId, string newJobTitle)
        {
            _employeeDAO.UpdateEmployee(employeeId, newJobTitle);
        }

        public void DeleteEmployee(int employeeId)
        {
            _employeeDAO.DeleteEmployee(employeeId);
        }

        public List<Employee> SearchEmployeeByName(string name)
        {
            return _employeeDAO.SearchEmployeeByName(name);
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _employeeDAO.GetEmployeeById(employeeId);
        }
    }

}
