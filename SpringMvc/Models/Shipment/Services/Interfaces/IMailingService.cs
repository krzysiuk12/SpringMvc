using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Shipment.Services.Interfaces
{
    public interface IMailingService
    {
        Boolean SendEmail(string to, string subject, string message);
    }
}