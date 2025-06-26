using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface ICustomerRepository
    {
        Customer? GetCustomerById(int customerId);
        Customer? GetCustomerByPhone(string phone);
        ObservableCollection<Customer> GetAllCustomers();
        bool AddCustomer(Customer customer);
        bool UpdateCustomer(int customerId, Customer newCustomer);
        bool DeleteCustomer(int customerId);
        List<Customer> SearchCustomerByName(string name);
    }


}
