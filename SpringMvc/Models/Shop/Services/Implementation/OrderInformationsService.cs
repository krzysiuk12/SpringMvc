using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.Common;

namespace SpringMvc.Models.Shop.Services.Implementation
{
    [Repository]
    public class OrderInformationsService : BaseSpringService, IOrderInformationsService
    {
        [Transaction(ReadOnly = true)]
        public Order GetOrderById(long orderId)
        {
            return DaoFactory.OrderInformationsDao.GetOrderById(orderId);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<Order> GetOrdersByUserId(long userId)
        {
            return DaoFactory.OrderInformationsDao.GetOrdersByUserId(userId);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<Order> GetUndeliveredOrders()
        {
            return DaoFactory.OrderInformationsDao.GetUndeliveredOrders();
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<Order> GetUndeliveredOrdersByUserId(long userId)
        {
            return DaoFactory.OrderInformationsDao.GetUndeliveredByUserId(userId);
        }
    }
}