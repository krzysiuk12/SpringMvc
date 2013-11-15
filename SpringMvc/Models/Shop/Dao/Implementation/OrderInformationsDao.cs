using SpringMvc.Models.Shop.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Common;

namespace SpringMvc.Models.Shop.Dao.Implementation
{
    public class OrderInformationsDao :  IOrderInformationsDao
    {
        public Order GetOrderById(long orderId)
        {
         //   return this.S
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersByUserId(long userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetInProgressOrders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetInProgressOrdersByUserId(long userId)
        {
            throw new NotImplementedException();
        }
    }
}