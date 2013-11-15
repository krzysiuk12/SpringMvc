using SpringMvc.Models.Shop.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Shop.Dao.Implementation
{
    public class OrderInformationsDao : IOrderInformationsDao
    {
        Order GetOrderById(long orderId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Order> GetOrdersByUserId(long userId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Order> GetInProgressOrders()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Order> GetInProgressOrdersByUserId(long userId)
        {
            throw new NotImplementedException();
        }
    }
}