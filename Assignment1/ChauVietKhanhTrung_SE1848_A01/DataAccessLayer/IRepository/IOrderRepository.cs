using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        ObservableCollection<Order> GetAllOrders();
        Order GetOrderById(int orderId);
        void UpdateOrder(Order updatedOrder);
        void DeleteOrder(int orderId);
        List<Order> SearchOrderByDate(DateTime startDate, DateTime endDate);
    }

}
