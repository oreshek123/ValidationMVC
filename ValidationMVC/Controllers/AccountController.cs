using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ValidationMVC.Models;

namespace ValidationMVC.Controllers
{
    public class AccountController : Controller
    {
        private FormService _service = new FormService();
        // GET: Account
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateOrder()
        {
            ViewBag.formOfPaymentId = new SelectList(_service.GetPaymentTypes(), "FormOfPaymentId", "Name");
            
            Sender sender = new Sender();
            return View(sender);
        }
        [HttpPost]
        public ActionResult CreateOrder(Sender sender)
        {
            ViewBag.formOfPaymentId = new SelectList(_service.GetPaymentTypes(), "FormOfPaymentId", "Name");
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Success";
                if( _service.CreateOrder(sender))
                return RedirectToAction("CreateTruck");
            }
            ViewBag.Message = "Error";
            return View(sender);
        }

        public ActionResult CreateTruck()
        {
            ViewBag.cityId = new SelectList(_service.GetCities(), "CityId", "CityName");
            ViewBag.countryId = new SelectList(_service.GetCountries(), "CountryId", "CountryName");
            ViewBag.DepartureTypeId = new SelectList(_service.GetDepartureTypes(), "DepartureTypeId", "DepartureTypeName");
            ViewBag.TariffsViewId = new SelectList(_service.GetTariffsViews(), "TariffsViewId", "TariffsViewName");
            DescriptionOfGood desc = new DescriptionOfGood();
            return View(desc);
        }

        [HttpPost]
        public ActionResult CreateTruck(DescriptionOfGood description)
        {
            ViewBag.cityId = new SelectList(_service.GetCities(), "CityId", "CityName");
            ViewBag.countryId = new SelectList(_service.GetCountries(), "CountryId", "CountryName");
            ViewBag.DepartureTypeId = new SelectList(_service.GetDepartureTypes(), "DepartureTypeId", "DepartureTypeName");
            ViewBag.TariffsViewId = new SelectList(_service.GetTariffsViews(), "TariffsViewId", "TariffsViewName");
            if (ModelState.IsValid)
            {
                if (_service.CreateTrack(description))
                {
                    ViewBag.Message = "Success";
                    return View("Index");
                }
            }
            ViewBag.Message = "Error";
            return View(description);
        }

    }
}