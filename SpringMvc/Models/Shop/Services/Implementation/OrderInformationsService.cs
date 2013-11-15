using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Services.Interfaces;

namespace SpringMvc.Models.Shop.Services.Implementation
{
    public class OrderInformationsService : IOrderInformationsService
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