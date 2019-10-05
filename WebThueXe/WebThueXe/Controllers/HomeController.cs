using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;


namespace WebThueXe.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? province, int page = 1, int pagesize = 6)
        {
            if (province !=null)
            {
                return RedirectToAction("Index", "FindCar");
            }
            var carDao = new CarDao();
            var contentDao = new ContentDao();
            ViewBag.NewCars = carDao.ListNewCar(4);
            ViewBag.ListFeatureCars = carDao.ListFeartureCar(8);
            ViewBag.ListNewContents = contentDao.ListNewContent(4);
            ViewBag.province = new ProvinceDao().ListAll();
            return View();
        }
        
        // GET: About
        public ActionResult About()
        {
            return View();
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }
    
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }
    }
}