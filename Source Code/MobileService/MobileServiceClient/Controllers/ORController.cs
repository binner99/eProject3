using Data;
using MobileServiceClient.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace MobileServiceClient.Controllers
{
    public class ORController : Controller
    {
        string url = "http://localhost:61560/api/Product/";
        HttpClient client = new HttpClient();
        public ORController()
        {
            ViewBag.Current = "OR";
        }

        public PartialViewResult _PriceListORNormal() => PartialView(client.GetAsync(url).Result.Content.ReadAsAsync<IEnumerable<Product>>().Result);
        public PartialViewResult _PriceListORSpecial() => PartialView(client.GetAsync(url).Result.Content.ReadAsAsync<IEnumerable<Product>>().Result);

        public ActionResult ORNormal() => View();
                       
        [HttpPost]
        public PartialViewResult NextPay(OR oR)
        {
            TempData["billPhone"] = oR.Phone;
            TempData["billTotal"] = oR.Amount;
            return PartialView();
        }
        public ActionResult ORSpecial() => View();
    }
}