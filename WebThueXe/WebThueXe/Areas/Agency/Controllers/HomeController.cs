using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebThueXe.Areas.Agency.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Agency/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}