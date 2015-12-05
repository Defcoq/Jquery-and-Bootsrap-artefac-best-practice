using JQuery.Bootstrap.AspNet.Best.Samples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQuery.Bootstrap.AspNet.Best.Samples.Controllers
{
    public class SortTableController : Controller
    {
        // GET: SortTable
        public ActionResult Index()
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var data = from e in db.Employees
                       orderby e.EmployeeID
                       select e;
            return View(data.ToList());

        }
    }
}