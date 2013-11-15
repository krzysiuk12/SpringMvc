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