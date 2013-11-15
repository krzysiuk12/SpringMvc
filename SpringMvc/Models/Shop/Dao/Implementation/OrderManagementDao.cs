using SpringMvc.Models.Shop.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Shop.Dao.Implementation
{
    public class OrderManagementDao : IOrderManagementDao
    {
        void CreateNewOrder(Order order)
        {
            throw new NotImplementedException();
        }

        void MarkOrderInProgress(long orderId)
        {
            throw new NotImplementedException();
        }

        void CompleteOrder(long orderId)
        {
            throw new NotImplementedException();
        }
    }
}