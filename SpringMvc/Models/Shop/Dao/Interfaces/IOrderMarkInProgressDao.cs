using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.Shop.Dao.Interfaces
{
    public interface IOrderMarkInProgressDao
    {
        void MarkInProgressOrder(long orderId);
    }
}