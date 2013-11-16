using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Storehouse.Services.Interfaces
{
    public interface IStorehouseManagementService
    {
        void AddCategory(String name);

        void AddBookType(String title, String authors, long CategoryID, long QuantityMapId,decimal price);

        void MarkSold(long id, int quantity);
    }
}
