using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.Common;
using SpringMvc.Models.Shop.Dao.Interfaces;

namespace SpringMvc.Models.Shop.Dao.Implementation
{
    public class OrderMarkInProgressDao : BaseHibernateDao, IOrderMarkInProgressDao
    {
        public void MarkInProgressOrder(long orderId)
        {
            throw new NotImplementedException();
        }
    }
}