using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Shop.Dao.Interfaces
{
    public class IOrderInformationsDao
    {
        Order GetOrderById(long orderId);

        IEnumerable<Order> GetOrdersByUserId(long userId);

        IEnumerable<Order> GetInProgressOrders();

        IEnumerable<Order> GetInProgressOrdersByUserId(long userId);
    }
}