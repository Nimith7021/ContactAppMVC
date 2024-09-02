using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactAppMVCApp.Controllers
{
    public class InvalidOperationsController : Controller
    {
        // GET: InvalidOperations
        public ActionResult InactiveUserOperation()
        {
            return View();
        }

        public ActionResult InactiveContactOperation()
        {
            return View();
        }

        public ActionResult DataNotFoundOperation()
        {
            return View();
        }
    }
}