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
    public class OrderDetailViewModel : INotifyPropertyChanged
    {
        private readonly IOrderDetailService _orderDetailService;

        private ObservableCollection<OrderDetail> _orderDetails;
        public ObservableCollection<OrderDetail> OrderDetails
        {
            get { return _orderDetails; }
            set
            {
                _orderDetails = value;
                OnPropertyChanged(nameof(OrderDetails));
            }
        }

        private OrderDetail _newOrderDetail;
        public OrderDetail NewOrderDetail
        {
            get { return _newOrderDetail; }
            set
            {
                _newOrderDetail = value;
                OnPropertyChanged(nameof(NewOrderDetail));
            }
        }

        private OrderDetail _selectedOrderDetail;
        public OrderDetail SelectedOrderDetail
        {
            get { return _selectedOrderDetail; }
            set
            {
                _selectedOrderDetail = value;
                OnPropertyChanged(nameof(SelectedOrderDetail));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public OrderDetailViewModel(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
            _newOrderDetail = new OrderDetail(); // Khởi tạo chi tiết đơn hàng mới
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            var orderDetails = _orderDetailService.GetAllOrderDetails();
            OrderDetails = new ObservableCollection<OrderDetail>(orderDetails);
        }

        public void AddOrderDetail()
        {
            if (NewOrderDetail != null)
            {
                _orderDetailService.AddOrderDetail(NewOrderDetail);
                LoadOrderDetails();
            }
        }

        public void UpdateOrderDetail()
        {
            if (SelectedOrderDetail != null)
            {
                _orderDetailService.UpdateOrderDetail(SelectedOrderDetail.OrderID, SelectedOrderDetail.ProductID,
                    SelectedOrderDetail.UnitPrice, SelectedOrderDetail.Quantity, SelectedOrderDetail.Discount);
                LoadOrderDetails();
            }
        }

        public void DeleteOrderDetail()
        {
            if (SelectedOrderDetail != null)
            {
                _orderDetailService.DeleteOrderDetail(SelectedOrderDetail.OrderID, SelectedOrderDetail.ProductID);
                LoadOrderDetails();
            }
        }

        public void GetOrderDetailsByOrderID(int orderId)
        {
            var result = _orderDetailService.GetOrderDetailsByOrderID(orderId);
            OrderDetails = new ObservableCollection<OrderDetail>(result);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
