using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Warehouse.Services.Interfaces
{
    interface ISuggestingRepository
    {
        List<BookType> GetAllBooks();
        List<BookType> GetBooksByCategory(String category);
    }
}
