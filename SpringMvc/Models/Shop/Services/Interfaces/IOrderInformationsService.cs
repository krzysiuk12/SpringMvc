using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.Shop.Dao.Interfaces;

namespace SpringMvc.Models.Shop.Services.Interfaces
{
    public interface IOrderInformationsService
    {
        IOrderInformationsDao OrderInformationsDao
        {
            set;
            get;
        }

        Order GetOrderById(long orderId);

        IEnumerable<Order> GetOrdersByUserId(long userId);

        IEnumerable<Order> GetUndeliveredOrders();

        IEnumerable<Order> GetUndeliveredOrdersByUserId(long userId);

        IEnumerable<Order> GetDeliveredOrdersByUserId(long userId);
    }
}
