using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.Common;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.Storehouse.Services.Interfaces;

namespace SpringMvc.Models.Storehouse.Services.Implementation
{
    [Repository]
    public class StorehouseManagementService : BaseSpringService, IStorehouseManagementService
    {
        [Transaction]
        public void AddCategory(String name)
        {
            Category category = new Category()
            {
                Name = name
            };
            DaoFactory.StorehouseManagamentDao.SaveCategory(category);
        }

        [Transaction]
        public void AddBookType(string title, string authors, decimal price, int quantity, Category category)
        {
            QuantityMap quantityMap = new QuantityMap()
            {
                Quantity = quantity
            };

            BookType newBookType = new BookType()
            {
                Title = title,
                Authors = authors,
                Price = price,
                QuantityMap = quantityMap,
                Category = category
            };

            DaoFactory.StorehouseManagamentDao.SaveBookType(newBookType);
        }

        [Transaction]
        public bool MarkSold(long bookTypeId, int quantity)
        {
            BookType bookType = DaoFactory.BooksInformationDao.GetBookTypeById(bookTypeId);

            if (bookType.QuantityMap.Quantity - quantity < 0)
                return false;
            else
            {
                bookType.QuantityMap.Quantity -= quantity;
                DaoFactory.StorehouseManagamentDao.UpdateQuantity(bookType);
                return true;
            }
        }
    }
}