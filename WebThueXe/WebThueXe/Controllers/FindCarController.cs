using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace WebThueXe.Controllers
{
    public class FindCarController : Controller
    {
        // GET: FindCar
        public ActionResult Index(int? province, string pickup_date, string dropoff_date, int page = 1, int pagesize = 6)
        {

            var carDao = new CarDao();
            var model = carDao.SearchAll(province, page, pagesize);

            if (pickup_date != null && dropoff_date != null)
            {
                DateTime ngaypickup = Convert.ToDateTime(pickup_date);
                DateTime ngaydropoff = Convert.ToDateTime(dropoff_date);
                foreach (var item in model)
                {
                    var result = new OrderDetailDao().CheckList(item.ID, ngaypickup, ngaydropoff);
                    if (result == 0)
                    {
                       item.Remove(item);
                    }
                }
            }
            ViewBag.ListPriceCars = carDao.ListPriceCar(5);
            ViewBag.carattribute = new CarAttributeDao().ListAll();
            ViewBag.carattributedetail = new CarAttributeDetailDao().ListAll();
            ViewBag.province = new ProvinceDao().ListAll();
            return View(model);
        }
    }
}