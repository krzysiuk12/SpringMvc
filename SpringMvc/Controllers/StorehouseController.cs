using SpringMvc.Models.Common.Interfaces;
using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringMvc.Controllers
{
    public class StorehouseController : Controller
    {

        private IServiceLocator ServiceLocator { get; set; }
        
        //
        // GET: /Storehouse/

        public ActionResult Index()
        {
            IEnumerable<BookType> books = ServiceLocator.BooksInformationService.GetAllBooks();
            return View(books);
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
