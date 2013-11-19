using SpringMvc.Models.Common.Interfaces;
using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringMvc.Controllers
{
    public class MainShopController : Controller
    {
        private IServiceLocator ServiceLocator { get; set; } 

        //
        // GET: /MainShop/

        public ActionResult Index()
        {
            IEnumerable<BookType> books = ServiceLocator.BooksInformationService.GetAllBooks();
            return View(books);
        }

        private void SetCurrentMenuPositions(int primaryMenuPosition, int? secondaryMenuPosition = null)
        {
            Session["PrimaryMenuPosition"] = primaryMenuPosition;
            Session["SecondaryMenuPosition"] = secondaryMenuPosition;
        }

    }
}
