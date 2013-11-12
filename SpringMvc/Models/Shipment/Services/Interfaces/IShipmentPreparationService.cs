using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Shipping.Services.Interfaces
{
    public interface IShipmentPreparationService
    {

        Address GetUserAddressById(long userId);
        IEnumerable<OrderInfo> GetUnrealisedOrdersDescriptions();
        IEnumerable<OrderEntryDetails> GetOrderEntriesInfoByOrderID(long orderId);
        void CompleteOrder(int orderId);
        void MarkOrderAsInProgress(int orderId);

    }
}