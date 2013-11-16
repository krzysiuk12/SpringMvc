using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Storehouse.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Storehouse.Dao.Implementation
{
    public class StorehouseManagementDao : BaseHibernateDao, IStorehouseManagementDao
    {
        public void AddCategory(string name)
        {
            throw new NotImplementedException();
        }

        public void AddBookType(string title, string authors, decimal price, int quantity, Category category)
        {
            throw new NotImplementedException();
        }

        public void MarkSold(long bookTypeId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}