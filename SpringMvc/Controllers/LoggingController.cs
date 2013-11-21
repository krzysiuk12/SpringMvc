using SpringMvc.Menu;
using SpringMvc.Menu.MenuElementMapping;
using SpringMvc.Models.Common;
using SpringMvc.Models.Common.Interfaces;
using SpringMvc.Models.POCO;
using SpringMvc.Models.UserAccountsPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringMvc.Controllers
{
    public class LoggingController : Controller
    {
        private IServiceLocator ServiceLocator { get; set; } 

        //
        // GET: /Logging/


        /*
         * ***************************************** Login/Logout Controller Part *****************************************
         */
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LogInModel loginModelData)
        {
            UserAccount user = ServiceLocator.AuthorizationService.LoginUser(loginModelData.UserName, loginModelData.Password);
            if (user != null)
            {
                Session["LoggedUserId"] = (long)user.Id;
                switch(user.Id)
                { 
                    case 1:
                        SetCurrentMenuPositions(MenuPanelsMapping.ADMINISTRATOR, MenuPrimaryPositionMappings.ADMINISTRATOR_VIEW_ALL_USER_ACCOUNTS);
                        Session["MenuObject"] = ServiceLocator.ApplicationScope.MenuProvider.AdministratorMenu;
                        break;
                    case 2:
                        SetCurrentMenuPositions(MenuPanelsMapping.WORKER, MenuPrimaryPositionMappings.WORKER_UNDELIVEREDORDERS);
                        Session["MenuObject"] = ServiceLocator.ApplicationScope.MenuProvider.WorkerMenu;
                        break;
                    default:
                        SetCurrentMenuPositions(MenuPanelsMapping.SHOP, MenuPrimaryPositionMappings.SHOP_VIEW_ALL_BOOKS);
                        Session["CurrentOrder"] = new Order() 
                        { 
                            User = user,
                            OrderEntries = new List<OrderEntry>()
                        };
                        Session["CurrentUser"] = (UserAccount)user;
                        Session["MenuObject"] = ServiceLocator.ApplicationScope.MenuProvider.UserAccountMenu;
                        break;
                }
                return RedirectToAction(((SpringMvc.Menu.MenuComponents.MenuComponent)Session["MenuObject"]).ControllerAction, ((SpringMvc.Menu.MenuComponents.MenuComponent)Session["MenuObject"]).ControllerName);
            } 
            else
            {
                return View();
            }
        }

        public ActionResult GuestLogin()
        {
            SetCurrentMenuPositions(MenuPanelsMapping.SHOP);
            Session["CurrentOrder"] = null;
            Session["LoggedUserId"] = (long)ApplicationScope.GuestId;
            Session["MenuObject"] = ServiceLocator.ApplicationScope.MenuProvider.GuestMenu;
            return RedirectToAction("Index", "MainShop");
        }

        public ActionResult Logout()
        {
            Session["CurrentOrder"] = null;
            Session["LoggedUserId"] = null;
            return RedirectToAction("Index", "Logging");
        }


        /*
         * ***************************************** Register Controller Part *****************************************
         */
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            UserAccount newUserAccount = new UserAccount() { Login = model.Login, Password = model.Password, Email = model.Email };
            ServiceLocator.AuthorizationService.RegisterUser(newUserAccount);
            return RedirectToAction("Create", "UserAccountPanel", new { userAccountId = newUserAccount.Id });
        }

        private void SetCurrentMenuPositions(int primaryMenuPosition, int? secondaryMenuPosition = null)
        {
            Session["PrimaryMenuPosition"] = primaryMenuPosition;
            Session["SecondaryMenuPosition"] = secondaryMenuPosition;
        }
    }
}
