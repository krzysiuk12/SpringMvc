using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Services.Interfaces;

namespace SpringMvc.Models.Shop.Services.Implementation
{
    public class OrderManagementService : IOrderManagementService
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