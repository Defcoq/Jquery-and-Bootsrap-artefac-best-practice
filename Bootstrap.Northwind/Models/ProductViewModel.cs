using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bootstrap.Northwind.Models
{
    public class ProductViewModel

    {

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }

        public bool Discontinued { get; set; }

        public string Status { get; set; }

    }
}