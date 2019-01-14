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
        public ActionResult Home() => View();
        // GET: Home
        public ActionResult Index() => View();
        [HttpPost]
        public PartialViewResult InfoBill(OR oR)
        {
            Session["billPhone"] = oR.Phone;
            Session["billTotal"] = oR.Amount;
            ViewBag.billPhone = oR.Phone;
            ViewBag.billTotal = oR.Amount;
            return PartialView();
        }
        [HttpPost]
        public ActionResult Bill(PaymentClient paymentClient)
        {
            var bill = new Bill
            {
                billCusName = paymentClient.Name,
                billPhone = Session["billPhone"].ToString(),
                billTotal = Double.Parse(Session["billTotal"].ToString()),
                billDate = DateTime.Now,
                billDes = "Recharge " + Double.Parse(Session["billTotal"].ToString()) + " (₹)"
            };
            var model = client.PostAsJsonAsync<Bill>(url, bill).Result;
            return RedirectToAction("Index");
        }
    }
}