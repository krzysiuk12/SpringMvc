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
        public bool AddQuantity(long bookTypeId,int quantity)
        {
            BookType bookType = DaoFactory.BooksInformationDao.GetBookTypeById(bookTypeId);

            if (bookType == null) return false;
            else
            {
                bookType.QuantityMap.Quantity += quantity;
                DaoFactory.StorehouseManagamentDao.UpdateQuantity(bookType);
                return true;
            }
        }
		[Transaction]
		public void AddBookType(string title, string authors, decimal price, int quantity, Category category, string imageURL)
		{
			QuantityMap quantityMap = new QuantityMap()
			{
				Quantity = quantity
			};

			BookImage image = new BookImage()
			{
				URL = imageURL
			};

			BookType newBookType = new BookType()
			{
				Title = title,
				Authors = authors,
				Price = price,
				QuantityMap = quantityMap,
				Category = category,
				Image = image
			};

			DaoFactory.StorehouseManagamentDao.SaveBookType(newBookType);
		}

        [Transaction]
        public bool MarkSold(long bookTypeId, int quantity)
        {
            BookType bookType = DaoFactory.BooksInformationDao.GetBookTypeById(bookTypeId);

            if (bookType == null) return false;
            if (bookType.QuantityMap.Quantity - quantity < 0)
                return false;
            else
            {
                bookType.QuantityMap.Quantity -= quantity;
                DaoFactory.StorehouseManagamentDao.UpdateQuantity(bookType);
                return true;
            }
        }

        [Transaction]
        public void SaveBookType(BookType bookType)
        {
            DaoFactory.StorehouseManagamentDao.SaveBookType(bookType);
        }

        [Transaction]
        public void SaveCategory(Category category)
        {
            DaoFactory.StorehouseManagamentDao.SaveCategory(category);
        }
    }
}