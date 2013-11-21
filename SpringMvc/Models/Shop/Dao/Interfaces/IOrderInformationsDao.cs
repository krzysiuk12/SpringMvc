using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Shop.Dao.Interfaces
{
    public interface IOrderInformationsDao
    {
        Order GetOrderById(long orderId);

        IEnumerable<Order> GetOrdersByUserId(long userId);

        IEnumerable<Order> GetUndeliveredOrders();

        IEnumerable<Order> GetUndeliveredByUserId(long userId);

        IEnumerable<Order> GetDeliveredOrdersByUserId(long userId);
    }
}