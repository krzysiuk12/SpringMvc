using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NMock2;
using SpringMvc.Models.Shipment.Services.Implementation;
using SpringMvc.Models.UserAccounts.Services.Interfaces;

namespace SpringMvc.Tests.Mocks.Shipment
{
    class ShipmentMock
    {
        ShipmentPreparationService _shipmentPreparationService;
        private IUserInformationService _userInformationService;
        private Mockery _mockery;

        public void Setup()
        {
            _mockery = new Mockery();
            _userInformationService = (IUserInformationService)_mockery.NewMock(typeof(IUserInformationService));
            _shipmentPreparationService = new ShipmentPreparationService();
        }
    }
}
