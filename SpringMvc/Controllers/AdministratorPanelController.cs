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
    public class AdministratorPanelController : Controller
    {
        private IServiceLocator ServiceLocator { get; set; }

        #region View All UserAccount Methods
        public ActionResult ViewAllUserAccounts()
        {
            IEnumerable<UserAccount> userAccounts = ServiceLocator.AccountManagementService.GetAllUserAccounts();
            return View(userAccounts);
        }
        #endregion

        #region Change User Status Methods
        public ActionResult ChangeUserStatus(long userId)
        {
            UserAccount user = ServiceLocator.UserInformationService.GetUserAccountById(userId);
            return View(user);
        }

        public ActionResult ChangeUserStatusForStatusId(long userId, int statusId)
        {
            switch (statusId)
            { 
                case (int)UserAccount.Status.ACTIVE:
                    ServiceLocator.AccountManagementService.TurnOnUser(userId);
                    break;
                case (int)UserAccount.Status.LOCKED_OUT:
                    ServiceLocator.AccountManagementService.LockUser(userId);
                    break;
                case (int)UserAccount.Status.REMOVED:
                    ServiceLocator.AccountManagementService.RemoveUser(userId);
                    break;
            }
            return RedirectToAction("ChangeUserStatus", "AdministratorPanel", new { userId = userId });
        }
        #endregion

        #region Change User Password Methods
        public ActionResult ChangeUserPassword(long userId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeUserPassword(long userId, ChangePasswordModel model)
        {
            ServiceLocator.AccountManagementService.ChangeUserPassword(userId, model.NewPassword);
            return RedirectToAction("ViewAllUserAccounts", "AdministratorPanel");
        }
        #endregion

        #region View User Information Method
        public ActionResult ViewUserInformation(long userId)
        {
            UserAccount userAccount = ServiceLocator.UserInformationService.GetUserAccountById(userId);
            return View(userAccount);
        }
        #endregion

        private void SetCurrentMenuPositions(int primaryMenuPosition, int? secondaryMenuPosition = null)
        {
            Session["PrimaryMenuPosition"] = primaryMenuPosition;
            Session["SecondaryMenuPosition"] = secondaryMenuPosition;
        }
    }
}
