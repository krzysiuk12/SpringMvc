using SpringMvc.Models.Common;
using SpringMvc.Models.Storehouse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Storehouse.Services.Implementation
{
    public class StorehouseManagementService : BaseSpringService, IStorehouseManagementService
    {

        void AddCategory(String name)
        {

        }

        void AddBookType(String title, String authors, long CategoryID, long QuantityMapId, decimal price)
        {

        }

        void MarkSold(long id, int quantity)
        {

        }
       
    }
}