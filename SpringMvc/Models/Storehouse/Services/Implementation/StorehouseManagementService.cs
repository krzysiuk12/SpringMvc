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
using SpringMvc.Models.Storehouse.Dao.Interfaces;

namespace SpringMvc.Models.Storehouse.Services.Implementation
{
    [Repository]
    public class StorehouseManagementService : BaseSpringService, IStorehouseManagementService
    {
        #region Dao
        private IStorehouseManagementDao storehouseManagementDao;
        public IStorehouseManagementDao StorehouseManagementDao
        {
            get
            {
                if (storehouseManagementDao == null)
                    return DaoFactory.StorehouseManagamentDao;
                return storehouseManagementDao;
            }
            set
            {
                storehouseManagementDao = value;
            }
        }
        #endregion

        [Transaction]
        public void AddCategory(String name)
        {
            Category category = new Category()
            {
                Name = name
            };
            StorehouseManagementDao.SaveCategory(category);
        }

        [Transaction]
        public bool AddQuantity(long bookTypeId,int quantity)
        {
            BookType bookType = DaoFactory.BooksInformationDao.GetBookTypeById(bookTypeId);

            if (bookType == null) return false;
            else
            {
                bookType.QuantityMap.Quantity += quantity;
                StorehouseManagementDao.UpdateQuantity(bookType);
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

            StorehouseManagementDao.SaveBookType(newBookType);
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
                StorehouseManagementDao.UpdateQuantity(bookType);
                return true;
            }
        }

        [Transaction]
        public void SaveBookType(BookType bookType)
        {
            StorehouseManagementDao.SaveBookType(bookType);
        }

        [Transaction]
        public void SaveCategory(Category category)
        {
            StorehouseManagementDao.SaveCategory(category);
        }
    }
}

