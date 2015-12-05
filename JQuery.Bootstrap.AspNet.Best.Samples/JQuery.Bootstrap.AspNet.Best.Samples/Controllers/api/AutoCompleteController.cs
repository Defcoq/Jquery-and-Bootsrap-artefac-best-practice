using JQuery.Bootstrap.AspNet.Best.Samples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api
{
   
    public class AutoCompleteController : ApiController
    {
    
        public static List<string> GetTitles(string title)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var data = (from e in db.Employees
                        where e.Title.StartsWith(title)
                        orderby e.Title
                        select e.Title).Distinct();
            return data.ToList();
        }
    }
}
