using MobileServiceClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileServiceClient.Controllers
{
    public class ORController : Controller
    {
        public ORController()
        {
            ViewBag.Current = "OR";
        }
        public ActionResult Index() => View();
        [HttpPost]
        public PartialViewResult NextPay(OR oR)
        {
            TempData["billPhone"] = oR.Phone;
            TempData["billTotal"] = oR.Amount;
            return PartialView();
        }
    }
}