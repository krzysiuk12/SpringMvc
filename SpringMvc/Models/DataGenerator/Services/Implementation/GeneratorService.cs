using SpringMvc.Models.Common;
using SpringMvc.Models.Common.Interfaces;
using SpringMvc.Models.DataGenerator.Services.Interfaces;
using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.DataGenerator.Services.Implementation
{
    public class GeneratorService : BaseSpringService, IGeneratorService
    {
        private IBookTypeGeneratorService BookTypeGeneratorService { get; set; }
        private IOrderGeneratorService OrderGeneratorService { get; set; }
        private IUserAccountGeneratorService UserAccountGeneratorService { get; set; }

		public List<BookType> GenerateShopContent()
        {
            List<Category> categories = BookTypeGeneratorService.GenerateCategories();
            foreach (Category category in categories)
            {
                ServiceLocator.StorehouseManagementService.SaveCategory(category);
            }
            List<QuantityMap> quantityMaps = BookTypeGeneratorService.GenerateQuantityMaps();
            List<BookType> books = BookTypeGeneratorService.GenerateBooks(categories, quantityMaps);
            foreach (BookType book in books)
            {
                ServiceLocator.StorehouseManagementService.SaveBookType(book);
            }
			return books;
        }

		public List<UserAccount> GenerateUsers()
        {
            List<Address> addresses = UserAccountGeneratorService.GenerateAddress();
            List<PersonalData> personalDatas = UserAccountGeneratorService.GeneratePersonalData(addresses);
            List<UserAccount> userAccounts = UserAccountGeneratorService.GenerateUsers(personalDatas);
            foreach (UserAccount account in userAccounts)
            {
                ServiceLocator.AccountAdministrationService.SaveOrUpdateUser(account);
            }
            IList<LogInOutEvent> logEvents = UserAccountGeneratorService.GenerateLogInOutEvents(userAccounts);
            foreach (LogInOutEvent logEvent in logEvents)
            {
                ServiceLocator.LogEventsService.SaveLogInOutEvent(logEvent);
            }
			return userAccounts;
        }

		public List<Order> GenerateOrders(List<BookType> books, List<UserAccount> userAccounts, List<VatMap> vatValues)
		{
            long index = 1;
			List<Order> orders = OrderGeneratorService.GenerateOrders(books, userAccounts);
			foreach(Order order in orders)
			{
				ServiceLocator.OrderManagementService.CreateNewOrder(order);
                if (index % 3 == 0)
                {               
                    ServiceLocator.OrderManagementService.MarkOrderSent(index);
                }
                if (index % 3 == 1)
                {
                    ServiceLocator.OrderManagementService.CompleteOrder(index);
                }
                index++;
			}

			List<Invoice> invoices = OrderGeneratorService.GenerateInvoices(orders, vatValues);
			foreach (Invoice invoice in invoices)
			{
				DaoFactory.CreateInvoiceDao.SaveInvoice(invoice);
			}

			return orders;
		}
    }
}