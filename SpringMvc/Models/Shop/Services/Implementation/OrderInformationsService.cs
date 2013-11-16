using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.Common;

namespace SpringMvc.Models.Shop.Services.Implementation
{
    public class OrderInformationsService : BaseSpringService, IOrderInformationsService
    {
        public Order GetOrderById(long orderId)
        {
            return DaoFactory.OrderInformationsDao.GetOrderById(orderId);
        }

        public IEnumerable<Order> GetOrdersByUserId(long userId)
        {
            return DaoFactory.OrderInformationsDao.GetOrdersByUserId(userId);
        }

        public IEnumerable<Order> GetInProgressOrders()
        {
            return DaoFactory.OrderInformationsDao.GetInProgressOrders();
        }

        public IEnumerable<Order> GetInProgressOrdersByUserId(long userId)
        {
            return DaoFactory.OrderInformationsDao.GetInProgressOrdersByUserId(userId);
        }
    }
}