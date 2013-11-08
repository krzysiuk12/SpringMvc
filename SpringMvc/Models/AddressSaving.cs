using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring.Transaction.Interceptor;
using Spring.Stereotype;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Common;
using NHibernate;

namespace SpringMvc.Models
{
    [Repository]
    public class AddressSaving : BaseHibernateDao, IAddressService
    {
        [Transaction]
        public void SaveAddress(Address address) 
        {
            this.Session.Save(address);
        }
    }
}