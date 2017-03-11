using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hackathon_ithuset.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            return View(((object)"Hej hej"));
        }

        // POST: Home
        [HttpPost]
        public ActionResult Index(string query)
        {
            query = string.Format("http://libris.kb.se/xsearch?query={0}&format=json", query);

            return View(((object)query));
        }
    }
}