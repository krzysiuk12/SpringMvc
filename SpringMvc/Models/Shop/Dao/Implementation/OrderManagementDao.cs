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
        public void CreateNewOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void MarkOrderInProgress(long orderId)
        {
            throw new NotImplementedException();
        }

        public void CompleteOrder(long orderId)
        {
            throw new NotImplementedException();
        }
    }
}