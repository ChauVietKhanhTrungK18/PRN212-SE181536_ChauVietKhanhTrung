using BusinessLayer.IService;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChauVietKhanhTrungWPF.ViewModels
{

    public class CustomerViewModel : INotifyPropertyChanged
    {
        private readonly ICustomerService _customerService;

        private ObservableCollection<Customer> _customers;
        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }
        private Customer _newCustomer;
        public Customer NewCustomer
        {
            get { return _newCustomer; }
            set
            {
                _newCustomer = value;
                OnPropertyChanged(nameof(NewCustomer));
            }
        }

        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CustomerViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
            _newCustomer = new Customer(); 
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            Customers = new ObservableCollection<Customer>(customers);
        }

        public void AddCustomer()
        {
            if (NewCustomer != null)
            {
                _customerService.AddCustomer(NewCustomer);
                LoadCustomers();
            }
        }

        public void UpdateCustomer()
        {
            if (SelectedCustomer != null)
            {
                _customerService.UpdateCustomer(SelectedCustomer.CustomerID, SelectedCustomer);
                LoadCustomers();
            }
        }

        public void DeleteCustomer()
        {
            if (SelectedCustomer != null)
            {
                _customerService.DeleteCustomer(SelectedCustomer.CustomerID);
                LoadCustomers();
            }
        }

        public void SearchCustomerByName(string name)
        {
            var result = _customerService.SearchCustomerByName(name);
            Customers = new ObservableCollection<Customer>(result);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
