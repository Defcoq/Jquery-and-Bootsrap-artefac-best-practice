using AutoMapper.QueryableExtensions;
using System.Web.Mvc;
using System.Linq;
using Northwind.Data.Models;
using Northwind.Infrastructure;
using Northwind.Web.Models;

namespace Northwind.Web.Controllers
{
    public class HomeController : NorthwindController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUser _currentUser;

        public HomeController(ApplicationDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";
            var models = _context.Employees.Project().To<EmployeeViewModel>().ToArray();
            return View(models);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}