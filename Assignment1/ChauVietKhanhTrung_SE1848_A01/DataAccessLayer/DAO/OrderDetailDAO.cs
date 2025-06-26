using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class OrderDetailDAO
    {
        private ObservableCollection<OrderDetail> _orderDetails;

        public OrderDetailDAO()
        {
            _orderDetails = new ObservableCollection<OrderDetail>
        {
            new OrderDetail { OrderID = 1, ProductID = 1, UnitPrice = 18.00m, Quantity = 5, Discount = 0.1m },  
            new OrderDetail { OrderID = 1, ProductID = 2, UnitPrice = 19.00m, Quantity = 3, Discount = 0.05m },
            new OrderDetail { OrderID = 2, ProductID = 3, UnitPrice = 10.00m, Quantity = 2, Discount = 0.2m }, 
            new OrderDetail { OrderID = 2, ProductID = 4, UnitPrice = 22.00m, Quantity = 1, Discount = 0.1m },  
            new OrderDetail { OrderID = 3, ProductID = 5, UnitPrice = 21.35m, Quantity = 3, Discount = 0.05m },
            new OrderDetail { OrderID = 3, ProductID = 6, UnitPrice = 25.00m, Quantity = 1, Discount = 0.15m },
            new OrderDetail { OrderID = 4, ProductID = 7, UnitPrice = 30.00m, Quantity = 4, Discount = 0.1m }, 
            new OrderDetail { OrderID = 5, ProductID = 8, UnitPrice = 40.00m, Quantity = 2, Discount = 0.1m },
            new OrderDetail { OrderID = 6, ProductID = 9, UnitPrice = 97.00m, Quantity = 1, Discount = 0.05m }, 
            new OrderDetail { OrderID = 6, ProductID = 10, UnitPrice = 31.00m, Quantity = 3, Discount = 0.1m },  
            new OrderDetail { OrderID = 7, ProductID = 11, UnitPrice = 21.00m, Quantity = 2, Discount = 0.1m },  
            new OrderDetail { OrderID = 7, ProductID = 12, UnitPrice = 38.00m, Quantity = 1, Discount = 0.15m }, 
            new OrderDetail { OrderID = 8, ProductID = 13, UnitPrice = 6.00m, Quantity = 5, Discount = 0.1m },
            new OrderDetail { OrderID = 8, ProductID = 14, UnitPrice = 23.25m, Quantity = 2, Discount = 0.05m },
            new OrderDetail { OrderID = 9, ProductID = 15, UnitPrice = 15.50m, Quantity = 3, Discount = 0.1m }, 
            new OrderDetail { OrderID = 10, ProductID = 16, UnitPrice = 17.45m, Quantity = 4, Discount = 0.05m } 
        };
        }
        public void AddOrderDetail(OrderDetail orderDetail) => _orderDetails.Add(orderDetail);
        public ObservableCollection<OrderDetail> GetAllOrderDetails() => _orderDetails;
        //public List<OrderDetail> GetOrderDetailsByOrderID(int orderId)
        //{
        //    return _orderDetails.Where(od => od.OrderID == orderId).ToList();
        //}
        public void UpdateOrderDetail(int orderId, int productId, decimal newUnitPrice, int newQuantity, decimal newDiscount)
        {
            var orderDetail = _orderDetails.FirstOrDefault(od => od.OrderID == orderId && od.ProductID == productId);
            if (orderDetail != null)
            {
                orderDetail.UnitPrice = newUnitPrice;
                orderDetail.Quantity = newQuantity;
                orderDetail.Discount = newDiscount;
            }
        }
        public void DeleteOrderDetail(int orderId, int productId)
        {
            var orderDetail = _orderDetails.FirstOrDefault(od => od.OrderID == orderId && od.ProductID == productId);
            if (orderDetail != null) _orderDetails.Remove(orderDetail);
        }
        public List<OrderDetail> GetOrderDetailsByOrderID(int orderId) =>
            _orderDetails.Where(od => od.OrderID == orderId).ToList();
    }

}
