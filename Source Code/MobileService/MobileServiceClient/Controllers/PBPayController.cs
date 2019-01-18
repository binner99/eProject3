using MobileServiceClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileServiceClient.Controllers
{
    public class PBPayController : Controller
    {
        public PBPayController()
        {
            ViewBag.Current = "PBPay";
        }
        // GET: PBPay
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult NextPay(PBpay pBpay)
        {
            TempData["billTotal"] = pBpay.Amount;
            TempData["billDes"] = pBpay.BillCode;
            return PartialView();
        }
    }
}