using SpringMvc.Menu;
using SpringMvc.Menu.MenuElementMapping;
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
    public class UserAccountPanelController : Controller
    {
        private IServiceLocator ServiceLocator { get; set; } 

        //
        // GET: /UserAccountPanel/

        public ActionResult Index()
        {
            SetCurrentMenuPositions(MenuPanelsMapping.USER_ACCOUNT, MenuPrimaryPositionMappings.USERACCOUNT_VIEW);
            UserAccount userAccount = ServiceLocator.UserInformationService.GetUserAccountById((long)Session["LoggedUserId"]);
            return View(userAccount);
        }

        //
        // GET: /UserAccountPanel/Create

        #region Create Methods
        public ActionResult Create(long userAccountId)
        {
            UserAccountModel userAccountModel = new UserAccountModel();
            userAccountModel.UserAccount = ServiceLocator.UserInformationService.GetUserAccountById(userAccountId);
            userAccountModel.PersonalData = new PersonalData();
            userAccountModel.Address = new Address();
            return View(userAccountModel);
        }

        [HttpPost]
        public ActionResult Create(long userAccountId, UserAccountModel model)
        {
            ServiceLocator.AuthorizationService.SaveNewUserPersonalData(userAccountId, model.PersonalData, model.Address);
            return RedirectToAction("Index", "Logging");
        }
        #endregion

        #region Edit Methods
        public ActionResult Edit()
        {
            SetCurrentMenuPositions(MenuPanelsMapping.USER_ACCOUNT, MenuPrimaryPositionMappings.USERACCOUNT_EDIT);
            UserAccount model = ServiceLocator.UserInformationService.GetUserAccountById((long)Session["LoggedUserId"]);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserAccount model)
        {
            ServiceLocator.AccountManagementService.EditUserPersonalData((long)Session["LoggedUserId"], model.PersonalData);
            return RedirectToAction("Index", "UserAccountPanel");
        }
        #endregion

        #region Change Password Methods
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            ServiceLocator.AccountManagementService.ChangePassword((long)Session["LoggedUserId"], model.OldPassword, model.NewPassword);
            return View();
        }
        #endregion

        #region Account Information Methods
        public ActionResult AccountInformation()
        {
            return View();
        }
        #endregion

        private void SetCurrentMenuPositions(int primaryMenuPosition, int? secondaryMenuPosition = null)
        {
            Session["PrimaryMenuPosition"] = primaryMenuPosition;
            Session["SecondaryMenuPosition"] = secondaryMenuPosition;
        }
    }
}
