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
                return RedirectToAction("Index", "MainShop");
            } else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult GuestIndex()
        {
            Session["LoggedUserId"] = (long)ApplicationScope.GuestId;
            return RedirectToAction("Index", "Logging");
        }

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
