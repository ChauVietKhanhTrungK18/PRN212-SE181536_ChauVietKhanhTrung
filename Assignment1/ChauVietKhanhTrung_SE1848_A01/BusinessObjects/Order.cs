using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Order : INotifyPropertyChanged
    {
        private int _orderID;
        private int _customerID;
        private int _employeeID;
        private DateTime _orderDate;
        private List<OrderDetail> _orderDetails;

        public int OrderID
        {
            get => _orderID;
            set
            {
                if (_orderID != value)
                {
                    _orderID = value;
                    OnPropertyChanged(nameof(OrderID));
                }
            }
        }

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

        public int EmployeeID
        {
            get => _employeeID;
            set
            {
                if (_employeeID != value)
                {
                    _employeeID = value;
                    OnPropertyChanged(nameof(EmployeeID));
                }
            }
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            set
            {
                if (_orderDate != value)
                {
                    _orderDate = value;
                    OnPropertyChanged(nameof(OrderDate));
                }
            }
        }

        public List<OrderDetail> OrderDetails
        {
            get => _orderDetails;
            set
            {
                if (_orderDetails != value)
                {
                    _orderDetails = value;
                    OnPropertyChanged(nameof(OrderDetails));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
