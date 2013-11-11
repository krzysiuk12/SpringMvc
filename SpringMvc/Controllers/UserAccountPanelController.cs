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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserAccountModel model)
        {
            return RedirectToAction("Index", "Logging");
        }
        #endregion

        //
        // GET: /UserAccountPanel/Edit/5

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
