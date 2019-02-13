using Data;
using Data.Vo;
using System.Net.Http;
using System.Web.Mvc;

namespace MobileServiceClient.Controllers
{
    public class AccountController : Controller
    {
        string url = "http://localhost:61560";
        HttpClient client = new HttpClient();
        public AccountController()
        {
            ViewBag.Current = "Account";
        }
        public bool TestLogin()
        {
            var test = Session["UserLogin"];
            if (string.IsNullOrEmpty(test.ToString()) || test == null)
            {
                return false;
            }
            return true;
        }
        public ActionResult Login()
        {
            Session["UserLogin"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            var status = client.PostAsJsonAsync<Login>(url + "/check/Member/", login).Result;

            if (status.IsSuccessStatusCode)
            {
                var model = status.Content.ReadAsAsync<Member>().Result;
                Session["UserLogin"] = model.memPhone;
                Session["UserName"] = model.memName;
                return RedirectToAction("MyAccount", "Account");
            }
            ModelState.AddModelError("", "Login Fails!");
            return View();
        }

        public ActionResult Register() => View();
        [HttpPost]
        public ActionResult Register(Register register)
        {
            var memNew = new Member()
            {
                memPhone = register.memPhone,
                memEmail = register.memEmail,
                memName = register.memName,
                memPass = register.memPass
            };
            var status = client.PostAsJsonAsync<Member>(url + "/api/Member/", memNew).Result;
            if (status.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Account");
            }
            ModelState.AddModelError("", "Register Fails!");
            return View();
        }
        public ActionResult MyAccount()
        {
            if (!TestLogin())
            {
                return RedirectToAction("Login", "Account");
            }
            var memPhone = Session["UserLogin"].ToString();
            var model = client.GetAsync(url + "/api/Member/" + memPhone).Result.Content.ReadAsAsync<Member>().Result;
            return View(model);
        }
        public ActionResult Service() => TestLogin() == false ? RedirectToAction("Login", "Account") : (ActionResult)View();
        public ActionResult History()
        {
            if (!TestLogin())
            {
                return RedirectToAction("Login", "Account");
            }
            var memPhone = Session["UserLogin"].ToString();
            var model = client.GetAsync(url + "/api/Bill/" + memPhone).Result.Content.ReadAsAsync<Member>().Result;
            return View(model);
        }
    }
}