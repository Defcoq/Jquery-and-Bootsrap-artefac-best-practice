using JQuery.Bootstrap.AspNet.Best.Samples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQuery.Bootstrap.AspNet.Best.Samples.Controllers
{
    public class CascadingDropDownController : Controller
    {
        // GET: CascadingDropDown
        public ActionResult Index()
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var data = from c in db.Categories
                       orderby c.CategoryName ascending
                       select c;
            List<Categories> items = data.ToList();
            items.Insert(0, new Categories() { CategoryID = -1, CategoryName = "Please Select" });
            SelectList categories = new SelectList(items, "CategoryID", "CategoryName");
            ViewData["categories"] = categories;
            return View();

        }

        public JsonResult GetProducts(int CategoryID)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var data = from s in db.Products
                       where s.CategoryID == CategoryID
                       orderby s.ProductName
                       select new { s.ProductID, s.ProductName };
            return Json(data.ToList());
        }

    }
}