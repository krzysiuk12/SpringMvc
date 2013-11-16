using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Storehouse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Storehouse.Services.Implementation
{
    public class BooksInformationService : BaseSpringService, IBooksInformationService
    {
        public IEnumerable<BookType> GetBooksByCategoryId(long categoryId)
        {
            return DaoFactory.BooksInformationDao.GetBooksByCategoryId(categoryId);
        }

        public IEnumerable<BookType> GetAllBooks()
        {
            return DaoFactory.BooksInformationDao.GetAllBooks();
        }

        public BookType GetBookTypeById(long bookTypeId)
        {
            return DaoFactory.BooksInformationDao.GetBookTypeById(bookTypeId);
        }
    }
}