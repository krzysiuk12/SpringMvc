using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Dao.Interfaces;
using NHibernate.Linq;

namespace SpringMvc.Models.Shop.Dao.Implementation
{
    public class OrderInformationDao : BaseHibernateDao, IOrderInformationDao
    {
        public POCO.Order GetOrderById(long orderId)
        {
            return this.Session.Query<Order>().Where(order => order.Id == orderId).Select(order => order).Single();
        }
    }
}