using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Warehouse.Services.Interfaces
{
    interface IStorehouseRepository
    {
        bool AddBookType(String title, String authors, String kind, int price);
        bool AddBooks(long id, int quantity);
        BookType GetBookTypeByID(long id);
    }
}
