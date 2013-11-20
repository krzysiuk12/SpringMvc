using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringMvc.Controllers
{
    public class StorehouseController : Controller
    {
        //
        // GET: /Storehouse/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddBookQuantityView()
        {
            return View();
        }

        public ActionResult AddBook()
        {
            return View();
        }
    }
}
