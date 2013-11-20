using SpringMvc.Menu.MenuElementMapping;
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
            SetCurrentMenuPositions(MenuPanelsMapping.SHOP, MapCategoryNameToShopSecondaryPosition(null));
            IEnumerable<BookType> books = ServiceLocator.BooksInformationService.GetAllBooks();
            return View(books);
        }

        public ActionResult UserOrdersView()
        {
            IEnumerable<OrderEntry> orderEntry = ServiceLocator.OrderInformationsService.GetOrderById(1).OrderEntries;
            return View(orderEntry);
        }

        public ActionResult BookDetails(long booktypeId)
        {
            BookType book = ServiceLocator.BooksInformationService.GetBookTypeById(booktypeId);
            return View(book);
        }

        public ActionResult CategoryBooksView(string name)
        {
            SetCurrentMenuPositions(MenuPanelsMapping.SHOP, MapCategoryNameToShopSecondaryPosition(name));
            IList<Category> categories = ServiceLocator.BooksInformationService.GetAllCategories();
            long categoryId = (from Category category in categories where category.Name.Equals(name) select category.Id).Single();
            IEnumerable<BookType> books = ServiceLocator.BooksInformationService.GetBooksByCategoryId(categoryId);
            return View(books);
        }

        public ActionResult GetBooksByCategory(string name)
        {
            if (name == null)
            {
                return RedirectToAction("Index", "MainShop");
            }
            else
            {
                return RedirectToAction("CategoryBooksView", "MainShop", new { name = name });
            }
        }

        private int MapCategoryNameToShopSecondaryPosition(string name)
        {
            switch (name)
            { 
                case "Fantasy":
                    return MenuPrimaryPositionMappings.SHOP_CATEGORY_FANTASY;
                case "Fiction/Literary":
                    return MenuPrimaryPositionMappings.SHOP_CATEGORY_FICTIONLITERARY;
                case "Suspense and Thrillers":
                    return MenuPrimaryPositionMappings.SHOP_CATEGORY_SUSPENCETHRILLERS;
                case "Western":
                    return MenuPrimaryPositionMappings.SHOP_CATEGORY_WESTERN;
                case "Action and Adventure":
                    return MenuPrimaryPositionMappings.SHOP_CATEGORY_ACTIONADVENTURE;
                case "Classics":
                    return MenuPrimaryPositionMappings.SHOP_CATEGORY_CLASSICS;
                case "General":
                    return MenuPrimaryPositionMappings.SHOP_CATEGORY_GENERAL;
                case "Mystery":
                    return MenuPrimaryPositionMappings.SHOP_CATEGORY_MYSTERY;
                case "Romance":
                    return MenuPrimaryPositionMappings.SHOP_CATEGORY_ROMANCE;
                case "Science Fiction":
                    return MenuPrimaryPositionMappings.SHOP_CATEGORY_SCIENCEFICTION;
                default:
                    return MenuPrimaryPositionMappings.SHOP_VIEW_ALL_BOOKS;
            }
        }

        private void SetCurrentMenuPositions(int primaryMenuPosition, int? secondaryMenuPosition = null)
        {
            Session["PrimaryMenuPosition"] = primaryMenuPosition;
            Session["SecondaryMenuPosition"] = secondaryMenuPosition;
        }

    }
}
