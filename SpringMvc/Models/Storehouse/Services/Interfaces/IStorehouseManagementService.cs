using SpringMvc.Models.POCO;
using SpringMvc.Models.Storehouse.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Storehouse.Services.Interfaces
{
    public interface IStorehouseManagementService
    {

        IStorehouseManagementDao StorehouseManagementDao
        {
            set;
            get;
        }
        void AddCategory(String name);
		
		void AddBookType(String title, String authors, decimal price, int quantity, Category category, string imageURL);

        bool MarkSold(long bookTypeId, int quantity);

        void SaveBookType(BookType bookType);

        void SaveCategory(Category category);

        bool AddQuantity(long bookTypeId, int quantity);
    }
}
