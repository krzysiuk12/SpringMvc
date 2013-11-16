using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Storehouse.Services.Interfaces
{
    public interface IStorehouseManagementService
    {
        void AddCategory(String name);

        void AddBookType(String title, String authors, decimal price, int quantity, Category category);

        void MarkSold(long bookTypeId, int quantity);
    }
}
