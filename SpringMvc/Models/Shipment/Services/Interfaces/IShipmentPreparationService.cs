using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Shipment.Services.Interfaces
{
    public interface IShipmentPreparationService
    {
        PersonalData GetUserPersonalDataById(long userId);
        IEnumerable<OrderEntry> GetOrderEntriesByOrderId(long orderId);
        IEnumerable<Order> GetUnrealizedOrders();
        void CompleteOrder(long orderId);
        void MarkOrderAsInProgress(long orderId);
    }
}
