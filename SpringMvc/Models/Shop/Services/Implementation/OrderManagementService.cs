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
using SpringMvc.Models.Storehouse.Services.Interfaces;

namespace SpringMvc.Models.Shop.Services.Implementation
{
    [Repository]
    public class OrderManagementService : BaseSpringService,  IOrderManagementService
    {
        private IOrderManagementDao orderManagementDao;
        private IOrderInformationsDao orderInformationDao;
        private IBooksInformationService booksInformationService;
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

        public IBooksInformationService BooksInformationService
        {
            get
            {
                if (booksInformationService == null)
                    return ServiceLocator.BooksInformationService;
                return booksInformationService;
            }
            set
            {
                booksInformationService = value;
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
            Order order = OrderInformationDao.GetOrderById(orderId);
            order.Status = Order.OrderState.SENT;
            order.SentDate = DateTime.Now;
            OrderManagementDao.SaveOrUpdate(order);
        }

        [Transaction]
        public void CompleteOrder(long orderId)
        {
            Order order = OrderInformationDao.GetOrderById(orderId);
            order.DeliveryDate = DateTime.Now;
            order.Status = Order.OrderState.DELIVERED;
            OrderManagementDao.SaveOrUpdate(order);
        }

        public void AddOrderEntry(Order order, long selectedBookTypeId, int amount)
        {
            BookType bookType = BooksInformationService.GetBookTypeById(selectedBookTypeId);
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