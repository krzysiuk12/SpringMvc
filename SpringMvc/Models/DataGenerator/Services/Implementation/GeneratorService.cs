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

        public void GenerateShopContent()
        {
            List<Category> categories = BookTypeGeneratorService.GenerateCategories();
            List<QuantityMap> quantityMaps = BookTypeGeneratorService.GenerateQuantityMaps();
            List<BookType> books = BookTypeGeneratorService.GenerateBooks(categories, quantityMaps);
        }

        public void GenerateUsers()
        {
            List<Address> addresses = UserAccountGeneratorService.GenerateAddress();
            List<PersonalData> personalDatas = UserAccountGeneratorService.GeneratePersonalData(addresses);
            List<UserAccount> userAccounts = UserAccountGeneratorService.GenerateUsers(personalDatas);
            foreach (UserAccount account in userAccounts)
            {
                ServiceLocator.AccountAdministrationService.SaveOrUpdateUser(account);
            }
        }
    }
}