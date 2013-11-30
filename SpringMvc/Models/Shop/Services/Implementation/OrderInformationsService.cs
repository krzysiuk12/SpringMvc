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
        #region Dao
        private IOrderInformationsDao orderInformationsDao;
        public IOrderInformationsDao OrderInformationsDao
        {
            get
            {
                if (orderInformationsDao == null)
                    return DaoFactory.OrderInformationsDao;
                return orderInformationsDao;
            }
            set
            {
                orderInformationsDao = value;
            }
        }

        private IOrderManagementDao orderManagementDao;
        public IOrderManagementDao OrderManagementDao
        {
            get
            {
                if (orderManagementDao == null)
                    return DaoFactory.OrderManagementDao;
                return orderManagementDao;
            }
            set
            {
                orderManagementDao = value;
            }
        }
        #endregion

        [Transaction(ReadOnly = true)]
        public Order GetOrderById(long orderId)
        {
            return OrderInformationsDao.GetOrderById(orderId);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<Order> GetOrdersByUserId(long userId)
        {
            return OrderInformationsDao.GetOrdersByUserId(userId);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<Order> GetUndeliveredOrders()
        {
            return OrderInformationsDao.GetUndeliveredOrders();
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<Order> GetUndeliveredOrdersByUserId(long userId)
        {
            return OrderInformationsDao.GetUndeliveredByUserId(userId);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<Order> GetDeliveredOrdersByUserId(long userId)
        {
            return OrderInformationsDao.GetDeliveredOrdersByUserId(userId);
        }
    }
}