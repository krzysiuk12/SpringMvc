using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Storehouse.Dao.Interfaces
{
    public interface IBooksInformationDao
    {
        IEnumerable<BookType> GetBooksByCategory(long CategoryId);

        IEnumerable<BookType> GetAllBooks();

        BookType GetBookById(long BookTypeId);
    }
}
