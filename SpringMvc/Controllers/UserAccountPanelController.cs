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
        private IServiceLocator serviceLocator;

        //
        // GET: /UserAccountPanel/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /UserAccountPanel/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /UserAccountPanel/Create

        #region Create Methods
        public ActionResult Create(UserAccount userAccount)
        {
            return View(userAccount);
        }

        [HttpPost]
        public ActionResult Create(UserAccount userAccount, UserAccountModel model)
        {
            userAccount.PersonalData = ConvertUserAccountModelToPersonalData(model);
            userAccount.PersonalData.UserAccount = userAccount;
            serviceLocator.AccountAdministrationService.SaveOrUpdateUser(userAccount);
            return RedirectToAction("Index", "Logging");
        }
        #endregion

        //
        // GET: /UserAccountPanel/Edit/5
        #region Edit Methods
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /UserAccountPanel/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, UserAccountModel model)
        {
            return View();
        }
        #endregion

        #region Delete Methods
        //
        // GET: /UserAccountPanel/Delete/5

        public ActionResult Delete(int id)
        {
            return RedirectToAction("Edit");
        }

        //
        // POST: /UserAccountPanel/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Convert Methods
        private PersonalData ConvertUserAccountModelToPersonalData(UserAccountModel model) 
        {
            PersonalData personalData = new PersonalData()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                PESEL = model.PESEL,
                MiddleName = model.MiddleName != null ? model.MiddleName : null,
                IdentityCardNumber = model.IdentityCardNumber != null ? model.IdentityCardNumber : null,
                PhoneNumber = model.PhoneNumber != null ? model.PhoneNumber : null,
            };
            Address address = new Address()
            {
                City = model.City,
                Country = model.Country,
                PersonalData = personalData,
                PostalCode = model.PostalCode,
                Street = model.Street
            };
            personalData.Address = address;
            return personalData;
        }
        #endregion
    }
}
