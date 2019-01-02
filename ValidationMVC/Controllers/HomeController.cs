using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ValidationMVC.Filters;
using ValidationMVC.Models;

namespace ValidationMVC.Controllers
{
    public class HomeController : Controller
    {
        private FormService _service = new FormService();
        public ActionResult Index()
        {                              
            return View();
        }


        public ActionResult FormRes()
        {
            ViewBag.MessageThemeId = new SelectList(_service.GetMessageThemes(), "MessageThemeId", "ThemeName");
            Feedback feedback = new Feedback();
            return View(feedback);
        }
        [HttpPost]
        public ActionResult FormRes(Feedback feedback)
        {
            ViewBag.MessageThemeId = new SelectList(_service.GetMessageThemes(), "MessageThemeId", "ThemeName");
            if (ModelState.IsValid)
            {                              
                _service.CreateFeedback(feedback);

            }
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