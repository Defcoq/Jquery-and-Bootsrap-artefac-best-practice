using JQuery.Bootstrap.AspNet.Best.Samples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JQuery.Bootstrap.AspNet.Best.Samples
{
    public partial class JQuery_Autocomple : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static List<string> GetTitles(string title)
        {
            NORTHWNDEntities db = new NORTHWNDEntities();
            var data = (from e in db.Employees
                        where e.Title.StartsWith(title)
                        orderby e.Title
                        select e.Title).Distinct();
            var result = data.ToList();
            return result;
        }

    }
}