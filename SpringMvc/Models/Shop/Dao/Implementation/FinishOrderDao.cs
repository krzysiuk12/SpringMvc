using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.Common;
using SpringMvc.Models.Shop.Dao.Interfaces;

namespace SpringMvc.Models.Shop.Dao.Implementation
{
    public class FinishOrderDao : BaseHibernateDao, IOrderInformationDao
    {

        public POCO.Order GetOrderById(long orderId)
        {
            throw new NotImplementedException();
        }
    }
}