using Data;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace MobileServiceClient_Admin.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {            
        }
        
        string url = "http://localhost:61560/api/Admin/";
        HttpClient client = new HttpClient();
        //Index
        [Authorize]
        public ActionResult Index() => View(client.GetAsync(url).Result.Content.ReadAsAsync<IEnumerable<Admin>>().Result);
        [Authorize]
        //Details
        public ActionResult Details(string adName) => View(client.GetAsync(url + adName).Result.Content.ReadAsAsync<Admin>().Result);
        [Authorize]
        //Upload
        [HttpPost]
        public JsonResult Upload()
        {
            var file = Request.Files[0];
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/img/Admin"), fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            file.SaveAs(path);
            return Json(new { UploadedFilename = Request.Files[0].FileName });
        }
        [Authorize]
        //Create
        public ActionResult Create()
        {
            ViewBag.User = HttpContext.User.Identity.Name;
           return View();
        }
        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            try
            {
                var status = client.PostAsJsonAsync<Admin>(url, admin).Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles ="superadmin")]
        //Delete
        public ActionResult Delete(string adName)
        {
            try
            {
                var status = client.DeleteAsync(url + adName).Result;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
