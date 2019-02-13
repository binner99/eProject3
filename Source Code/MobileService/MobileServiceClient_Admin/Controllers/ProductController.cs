using Data;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace MobileServiceClient_Admin.Controllers
{
    public class ProductController : Controller
    {
        string url = "http://localhost:61560/api/Product/";
        HttpClient client = new HttpClient();
        //Index
        public ActionResult Index() => View(client.GetAsync(url).Result.Content.ReadAsAsync<IEnumerable<Product>>().Result);

        //Details
        public ActionResult Details(int id) => View(client.GetAsync(url + id).Result.Content.ReadAsAsync<Product>().Result);

        //Create
        public ActionResult Create() => View();
        [HttpPost]
        public ActionResult Create(Product products)
        {
            try
            {
                var status = client.PostAsJsonAsync<Product>(url, products).Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Edit
        public ActionResult Edit(int id) => View(client.GetAsync(url + id).Result.Content.ReadAsAsync<Product>().Result);
        [HttpPost]
        public ActionResult Edit(string id, Product products)
        {
            try
            {
                var status = client.PutAsJsonAsync<Product>(url + id, products).Result;

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
            var status = client.DeleteAsync(url + id).Result;
            return RedirectToAction("Index");
        }
    }
}
