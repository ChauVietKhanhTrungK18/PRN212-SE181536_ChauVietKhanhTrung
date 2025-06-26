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
    public class OrderViewModel : INotifyPropertyChanged
    {
        private readonly IOrderService _orderService;

        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private Order _newOrder;
        public Order NewOrder
        {
            get { return _newOrder; }
            set
            {
                _newOrder = value;
                OnPropertyChanged(nameof(NewOrder));
            }
        }

        private Order _selectedOrder;
        public Order SelectedOrder
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public OrderViewModel(IOrderService orderService)
        {
            _orderService = orderService;
            _newOrder = new Order(); // Khởi tạo đơn hàng mới
            LoadOrders();
        }

        private void LoadOrders()
        {
            var orders = _orderService.GetAllOrders();
            Orders = new ObservableCollection<Order>(orders);
        }

        public void AddOrder()
        {
            if (NewOrder != null)
            {
                _orderService.AddOrder(NewOrder);
                LoadOrders();
            }
        }

        //public void UpdateOrder()
        //{
        //    if (SelectedOrder != null)
        //    {
        //        _orderService.UpdateOrder(SelectedOrder.OrderID, SelectedOrder.OrderDate);
        //        LoadOrders();
        //    }
        //}

        public void DeleteOrder()
        {
            if (SelectedOrder != null)
            {
                _orderService.DeleteOrder(SelectedOrder.OrderID);
                LoadOrders();
            }
        }

        public void SearchOrderByDate(DateTime startDate, DateTime endDate)
        {
            var result = _orderService.SearchOrderByDate(startDate, endDate);
            Orders = new ObservableCollection<Order>(result);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
