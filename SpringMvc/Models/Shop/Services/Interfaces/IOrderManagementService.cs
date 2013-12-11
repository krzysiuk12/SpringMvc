using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.Shop.Dao.Interfaces;

namespace SpringMvc.Models.Shop.Services.Interfaces
{
    public interface IOrderManagementService
    {
        IOrderManagementDao OrderManagementDao
        {
            get;
            set;
        }

        IOrderInformationsDao OrderInformationDao
        {
            get;
            set;
        }

        void CreateNewOrder(Order order);

        void AddOrderEntry(Order order, long selectedBookTypeId, int amount);
            
        void MarkOrderSent(long orderId);

        void CompleteOrder(long orderId);

		void SaveOrder(Order order);
    }
}
