using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.DataGenerator.Services.Interfaces
{
	public interface IOrderGeneratorService
	{
		//Order GenerateOrderEntriesForOrder(List<BookType> bookTypes, Order order, int bookAmountIndex);

		List<Order> GenerateOrders(List<BookType> bookTypes, List<UserAccount> userAccounts);



	}
}
