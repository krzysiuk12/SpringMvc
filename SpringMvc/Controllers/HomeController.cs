using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpringMvc.Models.Common;
using NHibernate;
using SpringMvc.Models.POCO;
using Spring.Context.Support;
using Spring.Context;
using Spring.Transaction;
using SpringMvc.Models;

namespace SpringMvc.Controllers
{
    public class HomeController : Controller
    {
        //private BaseHibernateDao baseHibernateDao;
        private IAddressService addressSaving;

        public IAddressService AddressSaving { get { return addressSaving; } set { this.addressSaving = value; } }
        //public BaseHibernateDao BaseHibernateDao { get { return baseHibernateDao; } set { this.baseHibernateDao = value; } }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            //BaseHibernateDao bhd = ctx.GetObject("BaseHibernateDao") as BaseHibernateDao;
            //AddressSaving address = (AddressSaving)ctx.GetObject("AddressSaving");
            AddressSaving.SaveAddress(new Address() { City = "Polska", Country = "Krakow", PostalCode = "12-213", Street = "Grodzka" });

            //using (ISession session = baseHibernateDao.Session)
            //{
            //    using (session.BeginTransaction())
            //    {
            //        Address address = new Address() { City = "Polska", Country = "Krakow", PostalCode = "12-213", Street = "Grodzka" };
            //        session.Save(address);
            //        try
            //        {
            //            session.Transaction.Commit();
            //        }
            //        catch (HibernateException ex)
            //        {
            //            session.Transaction.Rollback();
            //        }
            //    }
            //}

            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
