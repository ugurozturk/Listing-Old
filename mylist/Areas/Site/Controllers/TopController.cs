using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mylist.Areas.Site.Controllers
{
    public class TopController : Controller
    {
        // GET: Site/Top
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Top100Movie()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Top100TvSeries()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Top100Animes()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Top100Games()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}