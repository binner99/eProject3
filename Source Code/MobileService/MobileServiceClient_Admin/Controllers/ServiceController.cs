using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MobileServiceClient_Admin.Controllers
{
    public class ServiceController : Controller
    {
        string url = "http://localhost:61560/api/Service/";
        HttpClient client = new HttpClient();
        //Index
        public ActionResult Index() => View(client.GetAsync(url).Result.Content.ReadAsAsync<IEnumerable<Service>>().Result);

        //Details
        public ActionResult Details(int id) => View(client.GetAsync(url + id).Result.Content.ReadAsAsync<Service>().Result);

        //Create
        public ActionResult Create() => View();
        [HttpPost]
        public ActionResult Create(Service services)
        {
            try
            {
                var status = client.PostAsJsonAsync<Service>(url, services).Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Edit
        public ActionResult Edit(int id) => View(client.GetAsync(url + id).Result.Content.ReadAsAsync<Service>().Result);
        [HttpPost]
        public ActionResult Edit(string id, Service services)
        {
            try
            {
                var status = client.PutAsJsonAsync<Service>(url + id, services).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Delete
        public ActionResult Delete(int id)
        {
            try
            {
                var status = client.DeleteAsync(url + id).Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
