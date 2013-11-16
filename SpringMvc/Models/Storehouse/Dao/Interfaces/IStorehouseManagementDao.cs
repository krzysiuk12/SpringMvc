using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Storehouse.Dao.Interfaces
{
    public interface IStorehouseManagementDao
    {
        void AddCategory(String name);

        void AddBookType(String title, String authors, long CategoryID, long QuantityMapId, decimal price);

        void MarkSold(long id, int quantity);
    }
}