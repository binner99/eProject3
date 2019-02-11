using Data;
using System.Net.Http;
using System.Web.Mvc;

namespace MobileServiceClient_Admin.Controllers
{
    public class AdLoginController : Controller
    {
        string url = "http://localhost:61560/check/Admin/";
        HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            Session["UserAdmin"] = "";
            Session["ImageAdmin"] = "";
            Session["RoleAdmin"] = false;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            var status = client.PostAsJsonAsync<Admin>(url, admin).Result;

            if (status.IsSuccessStatusCode)
            {
                var model = status.Content.ReadAsAsync<Admin>().Result;
                Session["UserAdmin"] = model.adName;
                Session["RoleAdmin"] = model.adRole;
                Session["ImageAdmin"] = model.adImage;
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }
    }
}