using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Storehouse.Dao.Interfaces
{
    public interface IStorehouseManagementDao
    {
        void AddCategory(String name);

        void AddBookType(String title, String authors, decimal price, int quantity, Category category);

        void MarkSold(long bookTypeId, int quantity);
    }
}