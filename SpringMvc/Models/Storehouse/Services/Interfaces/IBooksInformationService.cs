using SpringMvc.Models.POCO;
using SpringMvc.Models.Storehouse.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Storehouse.Services.Interfaces
{
    public interface IBooksInformationService
    {
        IBooksInformationDao BooksInformationDao
        {
            set;
            get;
        }
        IEnumerable<BookType> GetBooksByCategoryId(long categoryId);

        IEnumerable<BookType> GetAllBooks();

        BookType GetBookTypeById(long bookTypeId);

        IList<Category> GetAllCategories();
    }
}
