﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileServiceClient.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {
            ViewBag.Current = "Account";
        }
        public ActionResult Login()
        {
            return View();
        }
    }
}