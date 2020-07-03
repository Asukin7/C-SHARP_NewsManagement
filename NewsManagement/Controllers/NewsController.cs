using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsManagement.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}