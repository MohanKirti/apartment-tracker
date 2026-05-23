using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApartmentTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Dashboard()
        {
            ViewBag.Title = "Dashboard";
            // TODO: Implement dashboard logic
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            return View();
        }

        public ActionResult Logout()
        {
            // TODO: Implement logout logic
            return RedirectToAction("Index");
        }
    }
}