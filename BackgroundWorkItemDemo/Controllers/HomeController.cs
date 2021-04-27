using BackgroundWorkItemDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace BackgroundWorkItemDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public ActionResult Run(FormCollection form)
        {
            Response.Write("<h1>Application Stared</h1>");
            HostingEnvironment.QueueBackgroundWorkItem(cancellationToken => new Worker().StartProcessing(cancellationToken));
            Response.Write("<h3>Background Task Started...</h3>");
            Response.Write("<h1>Application Ended </h1>(Now You can close this application...)");
            return View();
        }
    }
}
