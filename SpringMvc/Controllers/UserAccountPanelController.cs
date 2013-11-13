﻿using SpringMvc.Models.Common.Interfaces;
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
    }
}
