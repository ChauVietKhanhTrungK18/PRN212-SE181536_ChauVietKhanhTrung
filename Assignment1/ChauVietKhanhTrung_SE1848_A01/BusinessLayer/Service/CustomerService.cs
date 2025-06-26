using BusinessLayer.IService;
using BusinessObjects;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        public bool AuthenticateCustomer(string phone)
        {
            var customer = _customerRepository.GetCustomerByPhone(phone);
            return customer != null;
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        public ObservableCollection<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        public bool UpdateCustomer(int customerId, Customer newCustomer)
        {
            return _customerRepository.UpdateCustomer(customerId, newCustomer);
        }

        public bool DeleteCustomer(int customerId)
        {
            return  _customerRepository.DeleteCustomer(customerId);
        }

        public List<Customer> SearchCustomerByName(string name)
        {
            return _customerRepository.SearchCustomerByName(name);
        }

        public Customer? GetCustomerByPhone(string phone)
        {
            return _customerRepository.GetCustomerByPhone(phone);
        }
    }


}
