using BusinessObjects;
using DataAccessLayer.DAO;
using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDAO _customerDAO;

        public CustomerRepository()
        {
            _customerDAO = new CustomerDAO(); 
        }

        public Customer? GetCustomerById(int customerId)
        {
            return _customerDAO.GetCustomerById(customerId);
        }
        public Customer? GetCustomerByPhone(string phone)
        {
            return _customerDAO.GetCustomerByPhone(phone);
        }


        public ObservableCollection<Customer> GetAllCustomers()
        {
            return _customerDAO.GetAllCustomers();
        }

        public bool AddCustomer(Customer customer)
        {
           return  _customerDAO.AddCustomer(customer);
        }

        public bool UpdateCustomer(int customerId, Customer newCustomer)
        {
            return _customerDAO.UpdateCustomer(customerId, newCustomer);
        }

        public bool DeleteCustomer(int customerId)
        {
            return _customerDAO.DeleteCustomer(customerId);
        }

        public List<Customer> SearchCustomerByName(string name)
        {
            return _customerDAO.SearchCustomerByName(name);
        }
    }


}
