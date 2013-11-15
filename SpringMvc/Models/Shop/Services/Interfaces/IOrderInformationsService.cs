using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Shop.Services.Interfaces
{
    public interface IOrderInformationsService
    {
        Order GetOrderById(long orderId);
        IEnumerable<Order> GetOrdersByUserId(long userId);
        IEnumerable<Order> GetInProgressOrders();
        IEnumerable<Order> GetInProgressOrdersByUserId(long userId);
    }
}
