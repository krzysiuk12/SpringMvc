using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.Common;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.Shop.Dao.Interfaces;

namespace SpringMvc.Models.Shop.Services.Implementation
{
    [Repository]
    public class OrderManagementService : BaseSpringService,  IOrderManagementService
    {
        private IOrderManagementDao orderManagemntDao;
        public IOrderManagementDao OrderManagementDao
        {
            get
            {
                if (orderManagemntDao == null)
                    return DaoFactory.OrderManagementDao;
                return orderManagemntDao;
            }
            set
            {
                orderManagemntDao = value;
            }
        }

        [Transaction]
        public void CreateNewOrder(Order order)
        {
            order.Status = Order.OrderState.ORDERED;
            order.OrderDate = DateTime.Now;
            OrderManagementDao.SaveOrUpdate(order);
        }

        [Transaction]
        public void MarkOrderSent(long orderId)
        {
            Order order = DaoFactory.OrderInformationsDao.GetOrderById(orderId);
            order.Status = Order.OrderState.SENT;
            order.SentDate = DateTime.Now;
            DaoFactory.OrderManagementDao.SaveOrUpdate(order);
        }

        [Transaction]
        public void CompleteOrder(long orderId)
        {
            Order order = DaoFactory.OrderInformationsDao.GetOrderById(orderId);
            order.DeliveryDate = DateTime.Now;
            order.Status = Order.OrderState.DELIVERED;
            DaoFactory.OrderManagementDao.SaveOrUpdate(order);
        }

        public void AddOrderEntry(Order order, long selectedBookTypeId, int amount)
        {
            BookType bookType = ServiceLocator.BooksInformationService.GetBookTypeById(selectedBookTypeId);
            OrderEntry orderEntry = new OrderEntry()
            {
                BookType = bookType,
                Price = bookType.Price,
                Amount = amount
            };
            order.OrderEntries.Add(orderEntry);
        }

		[Transaction]
		public void SaveOrder(Order order)
		{
            OrderManagementDao.SaveOrUpdate(order);
		}
    }
}