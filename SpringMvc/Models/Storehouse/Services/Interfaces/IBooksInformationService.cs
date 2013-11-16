using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Storehouse.Services.Interfaces
{
    public interface IBooksInformationService
    {
        IEnumerable<BookType> GetBooksByCategoryId(long categoryId);

        IEnumerable<BookType> GetAllBooks();

        BookType GetBookById(long bookTypeId);
    }
}
