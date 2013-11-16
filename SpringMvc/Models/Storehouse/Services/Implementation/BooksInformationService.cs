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
            throw new NotImplementedException();
        }

        public IEnumerable<BookType> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public BookType GetBookById(long bookTypeId)
        {
            throw new NotImplementedException();
        }
    }
}