using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.Common;
using SpringMvc.Models.Shipment.Services.Interfaces;
using SpringMvc.Models.POCO;
using SpringMvc.Models.ShipmentPages;
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
        public IEnumerable<OrderEntryDetails> GetOrderEntriesInfoByOrderId(long orderId)
        {
            throw new NotImplementedException();
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<OrderInfo> GetUnrealizedOrdersDescriptions()
        {
            throw new NotImplementedException();
        }

        [Transaction]
        public void CompleteOrder(long orderId)
        {
            throw new NotImplementedException();
        }

        [Transaction]
        public void MarkOrderAsInProgress(long orderId)
        {
            throw new NotImplementedException();
        }
    }
}