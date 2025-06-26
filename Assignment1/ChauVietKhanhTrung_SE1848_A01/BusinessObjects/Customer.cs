using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Customer : INotifyPropertyChanged
    {
        private int _customerID;
        private string _companyName;
        private string? _contactName;
        private string? _contactTitle;
        private string? _address;
        private string? _phone;
        public int CustomerID
        {
            get => _customerID;
            set
            {
                if (_customerID != value)
                {
                    _customerID = value;
                    OnPropertyChanged(nameof(CustomerID));
                }
            }
        }

        public string CompanyName
        {
            get => _companyName;
            set
            {
                if (_companyName != value)
                {
                    _companyName = value;
                    OnPropertyChanged(nameof(CompanyName));
                }
            }
        }

        public string? ContactName
        {
            get => _contactName;
            set
            {
                if (_contactName != value)
                {
                    _contactName = value;
                    OnPropertyChanged(nameof(ContactName));
                }
            }
        }

        public string? ContactTitle
        {
            get => _contactTitle;
            set
            {
                if (_contactTitle != value)
                {
                    _contactTitle = value;
                    OnPropertyChanged(nameof(ContactTitle));
                }
            }
        }

        public string? Address
        {
            get => _address;
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        public string? Phone
        {
            get => _phone;
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void NotifyAll()
        {
            OnPropertyChanged("");
        }
    }
}
