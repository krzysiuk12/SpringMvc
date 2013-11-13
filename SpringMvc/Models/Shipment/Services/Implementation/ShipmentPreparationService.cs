using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.Common;
using SpringMvc.Models.Common.Interfaces;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shipment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Shipment.Services.Implementation
{
    [Repository]
    public class ShipmentPreparationService : BaseSpringService, IShipmentPreparationService
    {

        private IServiceLocator serviceLocator;

        public Address GetUserAddressById(long userId)
        {
            //UserAccount user = serviceLocator.UserInformationService.GetUserAccountById(1);

            Address fakeAddress = new Address();
            PersonalData fakeName = new PersonalData();
            fakeName.LastName = "Kowalski";
            fakeName.FirstName = "Jan";
            fakeAddress.City = "Krakow";
            fakeAddress.Country = "Poland";
            fakeAddress.PostalCode = "23-420";
            fakeAddress.Street = "Kawiory";
            fakeAddress.PersonalData = fakeName;

            return fakeAddress;
        }

        public IEnumerable<OrderInfo> GetUnrealisedOrdersDescriptions()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderEntryDetails> GetOrderEntriesInfoByOrderID(long orderId)
        {
            throw new NotImplementedException();
        }

        public void CompleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public void MarkOrderAsInProgress(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}