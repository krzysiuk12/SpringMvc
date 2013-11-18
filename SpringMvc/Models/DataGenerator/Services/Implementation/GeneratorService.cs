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
			return userAccounts;
        }

		public void GenerateOrders(List<BookType> books, List<UserAccount> userAccounts)
		{
			List<Order> orders = OrderGeneratorService.GenerateOrders(books, userAccounts);
			foreach(Order order in orders)
			{
				ServiceLocator.OrderManagementService.CreateNewOrder(order);
			}

		}
    }
}