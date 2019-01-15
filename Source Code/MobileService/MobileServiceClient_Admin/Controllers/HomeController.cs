using Data;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Web.Mvc;

namespace MobileServiceClient_Admin.Controllers
{
    public class HomeController : Controller
    {
        //public HomeController()
        //{            
        //}

        string url = "http://localhost:61560/api/Admin/";
        HttpClient client = new HttpClient();
        //Index        
        public ActionResult Index() => View(client.GetAsync(url).Result.Content.ReadAsAsync<IEnumerable<Admin>>().Result);

        //Details
        public ActionResult Details(string adName) => View(client.GetAsync(url + adName).Result.Content.ReadAsAsync<Admin>().Result);

        //Upload
        [HttpPost]
        public JsonResult Upload()
        {
            var file = Request.Files[0];
            var fileName = Path.GetExtension(file.FileName);
            var path = Path.Combine(Server.MapPath("~/img/Admin"), "Admin" + fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            file.SaveAs(path);
            return Json(new { UploadedFilename = Request.Files[0].FileName });
        }

        //Create
        public ActionResult Create() => View();
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
