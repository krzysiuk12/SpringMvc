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
        private IServiceLocator serviceLocator;

        //
        // GET: /Logging/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LogInModel loginModelData)
        {
            UserAccount user = serviceLocator.AuthorizationService.LoginUser(loginModelData.UserName, loginModelData.Password);
            Session["LoggedUser"] = user;
            //serviceLocator.SessionScope.LoggedUser = user;
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            UserAccount newUserAccount = new UserAccount() { Login = model.Login, Password = model.Password, Email = model.Email };
            serviceLocator.AuthorizationService.RegisterUser(newUserAccount);
            return RedirectToAction("Create", "UserAccountPanel", newUserAccount);
        }
    }
}
