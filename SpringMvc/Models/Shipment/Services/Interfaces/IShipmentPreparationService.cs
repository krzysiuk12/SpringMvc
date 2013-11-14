using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Shipment.Services.Interfaces
{
    public interface IShipmentPreparationService
    {

        Address GetUserAddressById(long userId);
        IEnumerable<OrderInfo> GetUnrealisedOrdersDescriptions();
        IEnumerable<OrderEntryDetails> GetOrderEntriesInfoByOrderID(long orderId);
        void CompleteOrder(long orderId);
        void MarkOrderAsInProgress(long orderId);

    }
}