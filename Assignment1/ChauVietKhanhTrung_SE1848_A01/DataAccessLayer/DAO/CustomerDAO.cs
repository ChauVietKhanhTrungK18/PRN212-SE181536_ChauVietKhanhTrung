using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class CustomerDAO
    {
        private ObservableCollection<Customer> _customers;

        public CustomerDAO()
        {
            _customers = new ObservableCollection<Customer>
            {
                new Customer { CustomerID = 1, CompanyName = "ABC Corp", ContactName = "John Doe", ContactTitle = "Manager", Address = "123 Elm St", Phone = "84291391642" },
                new Customer { CustomerID = 2, CompanyName = "XYZ Ltd", ContactName = "Jane Smith", ContactTitle = "Sales", Address = "456 Oak Rd", Phone = "84979116327" },
                new Customer { CustomerID = 3, CompanyName = "PQR Enterprises", ContactName = "Alice Johnson", ContactTitle = "CEO", Address = "789 Pine Ln", Phone = "84770647975" },
                new Customer { CustomerID = 4, CompanyName = "LMN Industries", ContactName = "Bob Brown", ContactTitle = "Director", Address = "101 Maple Ave", Phone = "84886628801" },
                new Customer { CustomerID = 5, CompanyName = "DEF Co.", ContactName = "Charlie Green", ContactTitle = "Support", Address = "202 Birch Blvd", Phone = "84467395998" },
                new Customer { CustomerID = 6, CompanyName = "GHI Corp", ContactName = "David Blue", ContactTitle = "Assistant", Address = "303 Oak Blvd", Phone = "84876194889" },
                new Customer { CustomerID = 7, CompanyName = "JKL Ltd", ContactName = "Eve White", ContactTitle = "Marketing", Address = "404 Cedar Ave", Phone = "84118817252" },
                new Customer { CustomerID = 8, CompanyName = "MNO Enterprises", ContactName = "Frank Black", ContactTitle = "Sales Manager", Address = "505 Elm Blvd", Phone = "84631130638" },
                new Customer { CustomerID = 9, CompanyName = "STU Industries", ContactName = "Grace Yellow", ContactTitle = "Product Manager", Address = "606 Pine St", Phone = "84748099209" },
                new Customer { CustomerID = 10, CompanyName = "VWX Corp", ContactName = "Henry Red", ContactTitle = "CEO", Address = "707 Maple St", Phone = "111-222-3333" }
            }; 
        }

        public Customer? GetCustomerByPhone(string phone)
        {
            return _customers.FirstOrDefault(c => c.Phone == phone);
        }
        public bool AddCustomer(Customer customer)
        {
            if (_customers.Any(c => c.CustomerID == customer.CustomerID))
            {
                return false; 
            }

            _customers.Add(customer); 
            return true; 
        }

        public ObservableCollection<Customer> GetAllCustomers() => _customers;

        public Customer GetCustomerById(int customerId) => _customers.FirstOrDefault(c => c.CustomerID == customerId);

        public bool UpdateCustomer(int customerId, Customer newCustomer)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerID == customerId);

            if (customer == null)
            {
                return false;
            }

            customer.CompanyName = newCustomer.CompanyName;
            customer.ContactName = newCustomer.ContactName;
            customer.ContactTitle = newCustomer.ContactTitle;
            customer.Address = newCustomer.Address;
            customer.Phone = newCustomer.Phone;

            return true;
        }

        public bool DeleteCustomer(int customerId)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerID == customerId);
            if (customer == null)
            {
                return false; 
            }

            _customers.Remove(customer); 
            return true; 
        }

        public List<Customer> SearchCustomerByName(string name) =>
            _customers.Where(c => c.CompanyName.Contains(name)).ToList();
    }

}
