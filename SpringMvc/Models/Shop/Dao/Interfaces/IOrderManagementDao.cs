using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Shop.Dao.Interfaces
{
    public interface IOrderManagementDao
    {
        void SaveOrUpdate(Order order);

        //void CreateNewOrder(Order order);

        //void MarkOrderInProgress(long orderId);

        //void CompleteOrder(long orderId);
    }
}