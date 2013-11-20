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
        public IEnumerable<Order> GetInProgressOrders()
        {
            return DaoFactory.OrderInformationsDao.GetInProgressOrders();
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<Order> GetInProgressOrdersByUserId(long userId)
        {
            return DaoFactory.OrderInformationsDao.GetInProgressOrdersByUserId(userId);
        }
    }
}