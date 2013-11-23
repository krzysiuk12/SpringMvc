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

        public ActionResult AddBookQuantity(long productId, int amount)
        {
            if (amount > 0)
                ServiceLocator.StorehouseManagementService.AddQuantity(productId, amount);

            return RedirectToAction("Index", "Storehouse");
        }

        public ActionResult AddBookSave(string authors, string title, Category category, decimal price, int quantity, BookImage image)
        {
            ServiceLocator.StorehouseManagementService.AddBookType(title, authors, price, quantity, category);
            return RedirectToAction("Index", "Storehouse");
        }

        public ActionResult AddBook()
        {           
            return View();
        }
    }
}
