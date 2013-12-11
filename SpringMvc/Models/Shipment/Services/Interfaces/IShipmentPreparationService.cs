using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.UserAccounts.Services.Interfaces;

namespace SpringMvc.Models.Shipment.Services.Interfaces
{
    public interface IShipmentPreparationService
    {

        IOrderInformationsService OrderInformationsService
        {
            get;
            set;
        }

        IOrderManagementService OrderManagementService
        {
            get;
            set;
        }

        IUserInformationService UserInformationService
        {
            get;
            set;
        }

        PersonalData GetUserPersonalDataById(long userId);
        IEnumerable<OrderEntry> GetOrderEntriesByOrderId(long orderId);
        IEnumerable<Order> GetUnrealizedOrders();
        void CompleteOrder(long orderId);
        void MarkOrderAsInProgress(long orderId);
    }
}
