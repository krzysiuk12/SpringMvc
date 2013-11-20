using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.Common;
using SpringMvc.Models.Shipment.Services.Interfaces;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SpringMvc.Models.Shipment.Services.Implementation
{
    [Repository]
    public class ShipmentPreparationService : BaseSpringService, IShipmentPreparationService
    {

        [Transaction(ReadOnly = true)]
        public PersonalData GetUserPersonalDataById(long userId)
        {
            UserAccount user = ServiceLocator.UserInformationService.GetUserAccountById(userId);
            Console.Write(user);
            if (user.PersonalData == null) throw new Exception();
            return user.PersonalData;
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<OrderEntry> GetOrderEntriesByOrderId(long orderId)       
        {
            return ServiceLocator.OrderInformationsService.GetOrderById(orderId).OrderEntries;
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<Order> GetUnrealizedOrders()
        {
            return ServiceLocator.OrderInformationsService.GetUndeliveredOrders();
        }

        [Transaction]
        public void CompleteOrder(long orderId)
        {

            ServiceLocator.OrderManagementService.CompleteOrder(orderId);
        }

        [Transaction]
        public void MarkOrderAsInProgress(long orderId) // metoda ustawia w order date wysłania i zmienia status na SENT
        {
            ServiceLocator.OrderManagementService.MarkOrderSent(orderId);
        }
    }
}