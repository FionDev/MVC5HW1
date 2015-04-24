using MVC5HW1.Models;
using MVC5HW1.Models.Interface;
using MVC5HW1.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5HW1.Controllers
{
    public class HomeController : Controller
    { 
        

        public HomeController()
        {
           

        }

        // GET: Custmers
        public ActionResult Index()
        {
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
    }
}