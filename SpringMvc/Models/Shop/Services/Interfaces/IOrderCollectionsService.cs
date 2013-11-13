using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Shop.Services.Interfaces
{
    public interface IOrderCollectionsService
    {
        IEnumerable<Order> GetOrdersByClientId(long clientId);
        IEnumerable<Order> GetInProgressOrders();
        IEnumerable<Order> GetInProgressOrdersByClient(long clientId);
    }
}
