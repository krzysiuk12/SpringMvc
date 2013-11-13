using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Shop.Dao.Interfaces
{
    public interface IOrderInformationDao
    {
        Order GetOrderById(long orderId);
    }
}