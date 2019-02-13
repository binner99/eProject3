using Data;
using MobileServiceClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MobileServiceClient.Controllers
{
    public class ContactController : Controller
    {
        string url = "http://localhost:61560/api/Feedback/";
        HttpClient client = new HttpClient();
        public ContactController()
        {
            ViewBag.Current = "Contact";
        }
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Feedback feedback)
        {
            try
            {
                var status = client.PostAsJsonAsync<Feedback>(url, feedback).Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}