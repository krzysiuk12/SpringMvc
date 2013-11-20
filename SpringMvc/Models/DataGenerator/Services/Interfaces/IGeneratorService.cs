using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.DataGenerator.Services.Interfaces
{
    public interface IGeneratorService
    {
        List<BookType> GenerateShopContent();

		List<UserAccount> GenerateUsers();

		List<Order> GenerateOrders(List<BookType> books, List<UserAccount> userAccounts, List<VatMap> vatValues);
    }
}
