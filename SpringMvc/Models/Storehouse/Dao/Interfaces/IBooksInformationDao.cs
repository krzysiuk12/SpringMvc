using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Storehouse.Dao.Interfaces
{
    public interface IBooksInformationDao
    {
        IEnumerable<BookType> GetBooksByCategoryId(long categoryId);

        IEnumerable<BookType> GetAllBooks();

        BookType GetBookTypeById(long bookTypeId);

        IList<Category> GetAllCategories();
    }
}
