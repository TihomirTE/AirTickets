﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirTickets.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.TheMessage = "About";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Having trouble ? Send us a message.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            // TODO: send message to adminastrator
            if (message == string.Empty)
            {
                ViewBag.TheMessage = "Message can not be empty! Try again!";

                return PartialView("_EmptyContact");
            }

            ViewBag.TheMessage = "Message sent";

            return PartialView("_ContactThanks");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "MVC 5 project";

            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }

            return RedirectToAction("Index");
        }
    }
}