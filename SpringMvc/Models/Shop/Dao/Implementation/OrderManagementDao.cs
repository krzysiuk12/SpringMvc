using SpringMvc.Models.Shop.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using NHibernate.Linq;
using SpringMvc.Models.Common;

namespace SpringMvc.Models.Shop.Dao.Implementation
{
    public class OrderManagementDao : BaseHibernateDao, IOrderManagementDao
    {
        public void SaveOrUpdate(Order order)
        {
            this.Session.SaveOrUpdate(order);
        }
    }
}