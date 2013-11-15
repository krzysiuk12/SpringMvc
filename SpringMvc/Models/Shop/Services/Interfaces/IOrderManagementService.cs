using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Shop.Services.Interfaces
{
    public interface IOrderManagementService
    {
        /// <summary>
        /// Method finishes Order and then return its new
        /// state
        /// </summary>
        /// <param name="orderId">Finishing order id</param>
        /// <returns>New order state</returns>
        Order CompleteOrder(long orderId);

        /// <summary>
        /// Method mark Order 'In Progress' and then return its new
        /// state
        /// </summary>
        /// <param name="orderId">Currently processing order id</param>
        /// <returns>New order state</returns>
        Order MarkOrderInProgress(long orderId);
    }
}
