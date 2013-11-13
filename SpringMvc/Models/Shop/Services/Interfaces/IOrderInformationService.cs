using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Shop.Services.Interfaces
{
    public interface IOrderInformationService
    {
        Order GetOrderById(long orderId);
    }
}
