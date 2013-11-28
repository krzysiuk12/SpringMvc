using SpringMvc.Models.Common.Interfaces;
using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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

		[HttpPost]
		public ActionResult AddBookSave(string authors, string title, Category category, decimal price, int quantity, HttpPostedFileBase image)
        {

			string fileName = category + "_" + ParseFileName(title) + Path.GetExtension(image.FileName);
			string path = System.IO.Path.Combine(Server.MapPath("~/Images/Books"), fileName);
			ServiceLocator.StorehouseManagementService.AddBookType(title, authors, price, quantity, category, "/Images/Books/" + fileName);

			image.SaveAs(path); 
            return RedirectToAction("Index", "Storehouse");
        }

        public ActionResult AddBook()
        {           
            return View();
        }

		private string ParseFileName(string text)
		{
			return Regex.Replace(text, "[^a-zA-Z0-9_]+", "", RegexOptions.Compiled);
		}
    }
}
