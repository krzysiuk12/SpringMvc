using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.Common;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;

namespace SpringMvc.Models.Shop.Services.Implementation
{
    [Repository]
    public class OrderManagementService : BaseSpringService,  IOrderManagementService
    {
        [Transaction]
        public void CreateNewOrder(Order order)
        {
            DaoFactory.OrderManagementDao.SaveOrUpdate(order);
        }

        [Transaction]
        public void MarkOrderInProgress(long orderId)
        {
            Order order = DaoFactory.OrderInformationsDao.GetOrderById(orderId);
            order.Status = Order.OrderState.IN_PROGRESS;
            DaoFactory.OrderManagementDao.SaveOrUpdate(order);
        }

        [Transaction]
        public void CompleteOrder(long orderId)
        {
            Order order = DaoFactory.OrderInformationsDao.GetOrderById(orderId);
            order.Status = Order.OrderState.DELIVERED;
            DaoFactory.OrderManagementDao.SaveOrUpdate(order);
        }

        [Transaction]
        public void OrderPaid(long orderId)
        {
            Order order = DaoFactory.OrderInformationsDao.GetOrderById(orderId);
            order.Status = Order.OrderState.PAID;
            DaoFactory.OrderManagementDao.SaveOrUpdate(order);
        }

        [Transaction]
        public void AddOrderEntry(Order order, OrderEntry orderEntry)
        {
            Order or = DaoFactory.OrderInformationsDao.GetOrderById(order.User.Id);
            or.OrderEntries.Add(orderEntry);
            DaoFactory.OrderManagementDao.SaveOrUpdate(order);
        }
    }
}