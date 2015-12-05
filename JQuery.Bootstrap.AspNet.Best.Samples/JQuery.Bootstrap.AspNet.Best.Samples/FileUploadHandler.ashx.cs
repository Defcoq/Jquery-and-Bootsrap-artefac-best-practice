using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JQuery.Bootstrap.AspNet.Best.Samples
{
    /// <summary>
    /// Summary description for FileUploadHandler
    /// </summary>
    public class FileUploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                HttpFileCollection files = context.Request.Files;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string fname = context.Server.MapPath
                    ("~/uploads/" + file.FileName);
                    file.SaveAs(fname);
                }
            }
            System.Threading.Thread.Sleep(10000);
            context.Response.ContentType = "text/plain";
            context.Response.Write("File(s) Uploaded Successfully!");
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}