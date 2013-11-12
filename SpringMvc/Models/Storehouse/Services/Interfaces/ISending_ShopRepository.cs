using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Warehouse.Services.Interfaces
{
    interface ISending_ShopRepository
    {
        bool MarkSold(long BookTypeId, int quantity);
        BookType GetBookTypeByID(long id);
    }
}