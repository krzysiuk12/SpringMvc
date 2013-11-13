using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Shop.Dao.Interfaces
{
    public interface IOrderCollectionDao
    {
        IEnumerable<Order> GetOrdersByClientId(long clientId);

        IEnumerable<Order> GetInProgressOrdersByClientId(long clientId);

        IEnumerable<Order> GetInProgressOrders();
    }
}