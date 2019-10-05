using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;

namespace WebThueXe.Controllers
{
    public class CarController : Controller
    {
        // GET: Car

        [ChildActionOnly]
        public PartialViewResult CarCategory()
        {
            var model = new CarCategoryDao().ListAll();
            return PartialView();
        }
        public ActionResult Detail(int id)
        {
            var car = new CarDao().ViewDetail(id);
            Session.Add("CarDetail", id);
            return View(car);
        }

        [HttpGet]
        public ActionResult OrderDetail(int id)
        {
            ViewBag.car = new CarDao().ViewDetail(id);
            return View();
        }

        [HttpPost]
        public ActionResult OrderDetail(OrderDetail info)
        {
            if (ModelState.IsValid)
            {
                var dao = new OrderDetailDao();
                var SessionCar = (int)Session["CarDetail"];
                info.CarId = SessionCar;
                long id = dao.Insert(info);
                Session.Add("OrderDetail", info.ID);
                if (id > 0)
                {
                    return RedirectToAction("Confirmation", "Car");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo hóa đơn không thành công");
                }
            }
            return View("OrderDetail");
        }

        public ActionResult Confirmation()
        {
            var SessionOrder = (int)Session["OrderDetail"];
            ViewBag.OrderDetail = new OrderDetailDao().ViewDetail(SessionOrder);
            ViewBag.CarDetail = new CarDao().ViewDetail(ViewBag.OrderDetail.CarId);
            ViewBag.Province = new ProvinceDao().ViewDetail(ViewBag.CarDetail.ProvinceId);
            return View();
        }

    }
} 