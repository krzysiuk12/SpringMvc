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
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.UserAccounts.Services.Interfaces;


namespace SpringMvc.Models.Shipment.Services.Implementation
{
    [Repository]
    public class ShipmentPreparationService : BaseSpringService, IShipmentPreparationService
    {
        private IOrderInformationsService orderInformationsService;
        private IOrderManagementService orderManagementService;

        public IOrderInformationsService OrderInformationsService
        {
            get
            {
                if (orderInformationsService == null)
                    return ServiceLocator.OrderInformationsService;
                return orderInformationsService;
            }
            set
            {
                orderInformationsService = value;
            }
        }

        public IOrderManagementService OrderManagementService
        {
            get
            {
                if (orderManagementService == null)
                    return ServiceLocator.OrderManagementService;
                return orderManagementService;
            }
            set
            {
                orderManagementService = value;
            }
        }
        
        [Transaction(ReadOnly = true)]
        public PersonalData GetUserPersonalDataById(long userId)
        {
            UserAccount user = UserInformationService.GetUserAccountById(userId);
            Console.Write(user);
            if (user.PersonalData == null) throw new Exception();
            return user.PersonalData;
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<OrderEntry> GetOrderEntriesByOrderId(long orderId)       
        {
            return OrderInformationsService.GetOrderById(orderId).OrderEntries;
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<Order> GetUnrealizedOrders()
        {
            return OrderInformationsService.GetUndeliveredOrders();
        }

        [Transaction]
        public void CompleteOrder(long orderId)
        {
            OrderManagementService.CompleteOrder(orderId);
        }

        [Transaction]
        public void MarkOrderAsInProgress(long orderId) // metoda ustawia w order date wysłania i zmienia status na SENT
        {
            OrderManagementService.MarkOrderSent(orderId);
        }

        private IUserInformationService userInformationService;
        public IUserInformationService UserInformationService
        {
            get
            {
                if (userInformationService == null)
                    return ServiceLocator.UserInformationService;
                return userInformationService;
            }
            set
            {
                userInformationService = value;
            }
        }
    }
}