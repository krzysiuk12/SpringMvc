using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.Common;
using SpringMvc.Models.Shop.Dao.Interfaces;

namespace SpringMvc.Models.Shop.Services.Implementation
{
    [Repository]
    public class OrderInformationsService : BaseSpringService, IOrderInformationsService
    {
        private IOrderInformationsDao orderInformationDao;

        public IOrderInformationsDao OrderInformationDao
        {
            get
            {
                if (orderInformationDao == null)
                    return DaoFactory.OrderInformationsDao;
                return orderInformationDao;
            }
            set
            {
                orderInformationDao = value;
            }
        }

        [Transaction(ReadOnly = true)]
        public Order GetOrderById(long orderId)
        {
            return OrderInformationDao.GetOrderById(orderId);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<Order> GetOrdersByUserId(long userId)
        {
            return OrderInformationDao.GetOrdersByUserId(userId);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<Order> GetUndeliveredOrders()
        {
            return OrderInformationDao.GetUndeliveredOrders();
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<Order> GetUndeliveredOrdersByUserId(long userId)
        {
            return OrderInformationDao.GetUndeliveredByUserId(userId);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<Order> GetDeliveredOrdersByUserId(long userId)
        {
            return OrderInformationDao.GetDeliveredOrdersByUserId(userId);
        }

        
    }
}