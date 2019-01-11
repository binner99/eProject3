using System;
using System.Net.Http;
using System.Web.Mvc;
using Data;
using MobileServiceClient.Models;

namespace MobileServiceClient.Controllers
{
    public class HomeController : Controller
    {
        string url = "http://localhost:61560/api/Bill/";
        HttpClient client = new HttpClient();
        // GET: Home
        public ActionResult Index() => View();
        
        public PartialViewResult NextPay(OR oR)
        {
            TempData["billPhone"] = oR.Phone;
            TempData["billTotal"] = oR.Amount;
            return PartialView();
        }
        [HttpPost]
        public ActionResult Bill(PaymentClient paymentClient)
        {
            var bill = new Bill
            {
                billCusName = paymentClient.Name,
                billPhone = TempData["billPhone"].ToString(),
                billTotal = Double.Parse(TempData["billTotal"].ToString()),
                billDate = DateTime.Now,
                billDes = "Recharge " + Double.Parse(TempData["billTotal"].ToString()) + " (₹)"
            };
            var model = client.PostAsJsonAsync<Bill>(url, bill).Result;
            return RedirectToAction("Index");
        }
    }
}