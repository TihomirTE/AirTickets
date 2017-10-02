using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirTickets.Web.Controllers
{
    public class SearchController : Controller
    {

        public ActionResult Flight()
        {
            return PartialView();
        }

        public ActionResult Hotel()
        {
            return PartialView();
        }
    }
}