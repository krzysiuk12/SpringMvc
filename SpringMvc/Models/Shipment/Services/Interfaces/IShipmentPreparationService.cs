using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.ShipmentPages;

namespace SpringMvc.Models.Shipment.Services.Interfaces
{
    public interface IShipmentPreparationService
    {
        PersonalData GetUserPersonalDataById(long userId);
        IEnumerable<OrderEntryDetails> GetOrderEntriesInfoByOrderId(long orderId);
        IEnumerable<OrderInfo> GetUnrealizedOrdersDescriptions();
        void CompleteOrder(long orderId);
        void MarkOrderAsInProgress(long orderId);
    }
}
