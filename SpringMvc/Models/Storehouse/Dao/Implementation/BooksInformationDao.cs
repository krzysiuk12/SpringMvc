using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Storehouse.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;


namespace SpringMvc.Models.Storehouse.Dao.Implementation
{

    public class BooksInformationDao : BaseHibernateDao, IBooksInformationDao
    {
        public IEnumerable<BookType> GetBooksByCategoryId(long categoryId)
        {
            return this.Session.Query<BookType>().Where(bookType => bookType.Category.Id == categoryId).Select(bookType => bookType).ToList();
        }

        public IEnumerable<BookType> GetAllBooks()
        {
            return this.Session.Query<BookType>().Where(bookType => bookType.Id != -1).Select(bookType => bookType).ToList();
        }

        public BookType GetBookById(long bookTypeId)
        {
            return this.Session.Query<BookType>().Where(bookType => bookType.Id == bookTypeId).Select(bookType => bookType).Single();
        }
    }
}