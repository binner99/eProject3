using Data;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace MobileServiceClient_Admin.Controllers
{
    public class AdLoginController : Controller
    {
        string url = "http://localhost:61560/check/Admin/";
        HttpClient client = new HttpClient();
        // GET: AdLogin
        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            var status = client.PostAsJsonAsync<Admin>(url, admin).Result;

            if (status.IsSuccessStatusCode)
            {
                FormsAuthentication.SetAuthCookie(admin.adName,false);
                return RedirectToAction("Index", "Home");
            }
            return View("Index");


        }
    }
}