using MobileServiceClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileServiceClient.Controllers
{
    public class ContactController : Controller
    {
        public ContactController()
        {
            ViewBag.Current = "Contact";
        }
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
    }
}