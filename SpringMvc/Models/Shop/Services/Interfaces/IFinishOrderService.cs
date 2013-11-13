using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Shop.Services.Interfaces
{
    interface IFinishOrderService
    {
        /// <summary>
        /// Method finishes Order and then return its new
        /// state
        /// </summary>
        /// <param name="orderId">Finishing order id</param>
        /// <returns>New order state</returns>
        Order CompleteOrder(long orderId);
    }
}
