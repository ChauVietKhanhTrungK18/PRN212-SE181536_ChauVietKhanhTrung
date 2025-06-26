using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface IEmployeeService
    {
        bool AuthenticateEmployee(string userName, string password);
        Employee GetEmployeeByUserName(string userName);
        List<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        void UpdateEmployee(int employeeId, string newJobTitle);
        void DeleteEmployee(int employeeId);
        List<Employee> SearchEmployeeByName(string name);
        Employee GetEmployeeById(int employeeId);
    }

}
