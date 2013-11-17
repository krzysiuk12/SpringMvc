using SpringMvc.Menu;
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
                        Session["MenuObject"] = ServiceLocator.ApplicationScope.MenuProvider.AdministratorMenu;
                        break;
                    case 2:
                        Session["MenuObject"] = ServiceLocator.ApplicationScope.MenuProvider.WorkerMenu;
                        break;
                    default:
                        Session["CurrentUser"] = (UserAccount)user;
                        Session["MenuObject"] = ServiceLocator.ApplicationScope.MenuProvider.UserAccountMenu;
                        break;
                }
                return RedirectToAction(((MenuObject)Session["MenuObject"]).PrimaryMenuPositions[((MenuObject)Session["MenuObject"]).CurrentPrimaryPosition].ControllerAction, ((MenuObject)Session["MenuObject"]).PrimaryMenuPositions[((MenuObject)Session["MenuObject"]).CurrentPrimaryPosition].ControllerName);
            } 
            else
            {
                return View();
            }
        }

        public ActionResult GuestLogin()
        {
            Session["LoggedUserId"] = (long)ApplicationScope.GuestId;
            Session["MenuObject"] = ServiceLocator.ApplicationScope.MenuProvider.GuestMenu;
            return RedirectToAction("Index", "MainShop");
        }

        public ActionResult Logout()
        {
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
    }
}
