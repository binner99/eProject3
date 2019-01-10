using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MobileServiceClient_Admin.Controllers
{
    public class BillController : Controller
    {
        string url = "http://localhost:61560/api/Bill/";
        HttpClient client = new HttpClient();
        //Index
        public ActionResult Index() => View(client.GetAsync(url).Result.Content.ReadAsAsync<IEnumerable<Bill>>().Result);

        //Details
        public ActionResult Details(int id) => View(client.GetAsync(url + id).Result.Content.ReadAsAsync<Bill>().Result);

    }
}
