using SpringMvc.Models.Common;
using SpringMvc.Models.Storehouse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Storehouse.Services.Implementation
{
    public class StorehouseManagementService : BaseSpringService, IStorehouseManagementService
    {
        public void AddCategory(string name)
        {
            throw new NotImplementedException();
        }

        public void AddBookType(string title, string authors, decimal price, int quantity, POCO.Category category)
        {
            throw new NotImplementedException();
        }

        public void MarkSold(long bookTypeId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}