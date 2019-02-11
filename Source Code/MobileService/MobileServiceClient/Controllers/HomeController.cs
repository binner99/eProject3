using Data;
using MobileServiceClient.Models;
using System;
using System.Net.Http;
using System.Web.Mvc;

namespace MobileServiceClient.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            ViewBag.Header = "Welcome to KMobile";            
        }
        string url = "http://localhost:61560/api/Bill/";
        HttpClient client = new HttpClient();
        public ActionResult Home() => View(ViewBag.Current = "Home");
        // GET: Home
        public ActionResult Index()
        {
            Session["UserLogin"] = "";
            return View();            
        }
        //[HttpPost]
        public void InfoBill(OR oR)
        {
            Session["billPhone"] = oR.Phone;
            Session["billTotal"] = oR.Amount;
            ViewData["Phone"] = oR.Phone;
            ViewData["Amount"] = oR.Amount;
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
            TempData["msg"] = "<p style='color:yellow;'>You Recharged Successfull !</p>";
            return RedirectToAction("Index");
        }
    }
}