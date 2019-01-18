using System;
using System.Collections.Generic;
using RemoteAPI.Migrations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RemoteAPI.Models;

namespace RemoteAPI.Controllers
{
    public class HomeController : Controller
    {
        public static void CreateDabase()
        {
            var db = new ConnectDatabase();
            db.Database.Initialize(true);
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ConnectDatabase, Configuration>());
            CreateDabase();
            return View();
        }
        
    }
}
