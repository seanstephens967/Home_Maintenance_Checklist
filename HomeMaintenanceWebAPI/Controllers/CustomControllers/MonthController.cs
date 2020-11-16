using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeMaintenanceWebAPI.Controllers.CustomControllers
{
    public class MonthController : Controller
    {
        // GET: Month
        public ActionResult Index()
        {
            return View();
        }
    }
}