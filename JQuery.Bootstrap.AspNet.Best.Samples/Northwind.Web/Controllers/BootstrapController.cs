using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Web.Controllers
{
    public class BootstrapController : Controller
    {
        public ActionResult Buttons()
        {
            return View();
        }

        public ActionResult Progressbars()
        {
            return View();
        }

        public ActionResult Alerts()
        {
            return View();
        }
	}
}