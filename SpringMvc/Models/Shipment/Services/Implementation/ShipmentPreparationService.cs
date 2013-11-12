using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shipping.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Shipment.Services.Implementation
{
    public class ShipmentPreparationService : IShipmentPreparationService
    {

        public Address GetUserAddressById(long userId)
        {
            //UserAccount user = serviceLocator.UserInformationService.GetUserAccountById(1);

            Address fakeAddress = new Address();
            fakeAddress.City = "Krakow";
            fakeAddress.Country = "Poland";
            fakeAddress.PostalCode = "23-420";
            fakeAddress.Street = "Kawiory";
            fakeAddress.PersonalData.LastName = "Kowalski";
            fakeAddress.PersonalData.FirstName = "Jan";

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