using SpringMvc.Models.Common;
using SpringMvc.Models.Shipment.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.ShipmentPages;

namespace SpringMvc.Models.Shipment.Services.Implementation
{
    public class ShipmentPreparationService : BaseSpringService, IShipmentPreparationService
    {
        public PersonalData GetUserPersonalDataById(long orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderEntryDetails> GetOrderEntriesInfoByOrderId(long orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderInfo> GetUnrealizedOrdersDescriptions()
        {
            throw new NotImplementedException();
        }

        public void CompleteOrder(long orderId)
        {
            throw new NotImplementedException();
        }

        public void MarkOrderAsInProgress(long orderId)
        {
            throw new NotImplementedException();
        }
    }
}