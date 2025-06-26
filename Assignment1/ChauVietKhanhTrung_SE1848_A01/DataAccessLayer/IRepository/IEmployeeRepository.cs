using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeByUserName(string userName);
        List<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        void UpdateEmployee(int employeeId, string newJobTitle);
        void DeleteEmployee(int employeeId);
        List<Employee> SearchEmployeeByName(string name);
        Employee GetEmployeeById(int employeeId);
    }

}
