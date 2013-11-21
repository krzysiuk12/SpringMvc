using SpringMvc.Models.Shop.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Common;
using NHibernate.Linq;

namespace SpringMvc.Models.Shop.Dao.Implementation
{
    public class OrderInformationsDao : BaseHibernateDao, IOrderInformationsDao
    {
        public Order GetOrderById(long orderId)
        {
            return this.Session.Query<Order>().Where(order => order.Id == orderId).Select(order => order).Single();
        }

        public IEnumerable<Order> GetOrdersByUserId(long userId)
        {
            return this.Session.Query<Order>().Where(order => order.User.Id == userId).Select(order => order).ToList();
        }

        public IEnumerable<Order> GetUndeliveredOrders()
        {
            return this.Session.Query<Order>().Where(order => order.Status != Order.OrderState.DELIVERED).Select(order => order).ToList();
        }

        public IEnumerable<Order> GetUndeliveredByUserId(long userId)
        {
            return this.Session.Query<Order>().Where(order => (order.Status != Order.OrderState.DELIVERED && order.User.Id == userId )).Select(order => order).ToList();
        }

        public IEnumerable<Order> GetDeliveredOrdersByUserId(long userId)
        {
            return this.Session.Query<Order>().Where(order => (order.Status == Order.OrderState.DELIVERED && order.User.Id == userId)).Select(order => order).ToList();
        }
    }
}