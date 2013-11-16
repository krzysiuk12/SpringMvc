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
        
        public IEnumerable<BookType> GetBooksByCategory(long CategoryId)
        {
            return DaoFactory.BooksInformationDao.GetBooksByCategory(CategoryId);
        }

        public IEnumerable<BookType> GetAllBooks()
        {
            return DaoFactory.BooksInformationDao.GetAllBooks();

        }

        public BookType GetBookById(long BookTypeId)
        {
            return DaoFactory.BooksInformationDao.GetBookById(BookTypeId);
        }

    }
}