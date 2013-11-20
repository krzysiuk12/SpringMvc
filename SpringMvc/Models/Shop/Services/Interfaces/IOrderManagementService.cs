using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Shop.Services.Interfaces
{
    public interface IOrderManagementService
    {
        void CreateNewOrder(Order order);

        void AddOrderEntry(Order order, long selectedBookTypeId, int amount);
            
        void MarkOrderSent(long orderId);

        void CompleteOrder(long orderId);
    }
}
