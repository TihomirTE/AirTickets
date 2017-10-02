using AirTickets.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirTickets.Web.Controllers
{
    public class ViewProfileController : Controller
    {
        // GET: ViewProfile
        public ActionResult Index()
        {
            return View();
        }

        // GET: ViewProfile/Details/
        // TODO: to view details profile -> have Id of the user
        public ActionResult Details()
        {
            var viewProfile = new ViewProfile
            {
                Id = 1,
                FirstName = "Kiro",
                LastName = "Roki",
                NumberOfTickets = 3
            };

            return View(viewProfile);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}