using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Shop.Services.Interfaces
{
    public interface IOrderMarkInProgressDao
    {
        /// <summary>
        /// Method mark Order 'In Progress' and then return its new
        /// state
        /// </summary>
        /// <param name="orderId">Currently processing order id</param>
        /// <returns>New order state</returns>
        Order MarkOrderInProgress(long orderId);
    }
}
