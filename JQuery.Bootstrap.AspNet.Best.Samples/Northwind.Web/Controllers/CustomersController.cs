using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Northwind.Data.Models;
using Northwind.Infrastructure;
using Northwind.Web.Models;
using PagedList;

namespace Northwind.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUser _currentUser;

        public CustomersController(ApplicationDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public ActionResult Index(int? page)
        {
            var model = _context.Customers.Project().To<CustomerViewModel>().OrderBy(p => p.CompanyName);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = _context.Customers.First(c => c.CustomerId == id);
            return View(model);
        }
    }
}