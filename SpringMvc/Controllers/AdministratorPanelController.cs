﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpringMvc.Controllers
{
    public class AdministratorPanelController : Controller
    {
        //
        // GET: /AdministratorPanel/

        public ActionResult ViewAllUserAccounts()
        {
            return View();
        }

        public ActionResult ChangeUserStatus()
        {
            return View();
        }

        public ActionResult ChangeUserPassword()
        {
            return View();
        }

        public ActionResult ViewUserInformation()
        {
            return View();
        }
    }
}
