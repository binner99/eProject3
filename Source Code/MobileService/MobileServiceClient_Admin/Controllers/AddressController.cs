using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MobileServiceClient_Admin.Controllers
{
    public class AddressController : Controller
    {
        string url = "http://localhost:61560/api/Address/";
        HttpClient client = new HttpClient();
        //Index
        public ActionResult Index() => View(client.GetAsync(url).Result.Content.ReadAsAsync<IEnumerable<Address>>().Result);

        //Details
        public ActionResult Details(int id) => View(client.GetAsync(url + id).Result.Content.ReadAsAsync<Address>().Result);

        //Create
        public ActionResult Create() => View();
        [HttpPost]
        public ActionResult Create(Address addresses)
        {
            try
            {
                var status = client.PostAsJsonAsync<Address>(url, addresses).Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Edit
        public ActionResult Edit(int id) => View(client.GetAsync(url + id).Result.Content.ReadAsAsync<Address>().Result);
        [HttpPost]
        public ActionResult Edit(string id, Address addresses)
        {
            try
            {
                var status = client.PutAsJsonAsync<Address>(url + id, addresses).Result;

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