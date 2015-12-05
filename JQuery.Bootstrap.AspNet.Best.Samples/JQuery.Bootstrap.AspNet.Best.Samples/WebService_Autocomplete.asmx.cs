using JQuery.Bootstrap.AspNet.Best.Samples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace JQuery.Bootstrap.AspNet.Best.Samples
{
    /// <summary>
    /// Summary description for WebService_Autocomplete
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService_Autocomplete : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod]
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
