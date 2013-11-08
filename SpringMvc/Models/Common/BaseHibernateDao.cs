using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace SpringMvc.Models.Common
{
    public abstract class BaseHibernateDao
    {
        private ISessionFactory sessionFactory;

        public ISessionFactory SessionFactory
        {
            get { return sessionFactory; }
            set { this.sessionFactory = value;  }
        }

        public ISession Session
        {
            get { return SessionFactory.GetCurrentSession();  }
        }
    }
}