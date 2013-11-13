using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Dao.Interfaces;

namespace SpringMvc.Models.Shop.Dao.Implementation
{
    public class OrderCollectionDao : BaseHibernateDao, IOrderCollectionDao
    {

        public IEnumerable<Order> GetOrdersByClientId(long clientId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetInProgressOrdersByClientId(long clientId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetInProgressOrders()
        {
            throw new NotImplementedException();
        }
    }
}