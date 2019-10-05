using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebThueXe.Areas.Agency.Controllers
{
    public class CarController : BaseController
    {
        // GET: Agency/Car
        public ActionResult Index(string searchString, int id, int page = 1, int pageSize = 10)
        {
            var dao = new CarDao();
            var model = dao.ListAllPagingByAgency(searchString, id, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]

        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                var dao = new CarDao();
                long id = dao.Insert(car);
                if (id > 0)
                {
                    SetAlert("Thêm Xe thành công", "success");
                    return RedirectToAction("Index", "Car");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Xe không thành công");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var car = new CarDao().ViewDetail(id);
            SetViewBag();
            return View(car);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                var dao = new CarDao();              
                var result = dao.Update(car);
                if (result)
                {
                    return RedirectToAction("Index", "Car");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Xe không thành công");
                }
            }
            SetViewBag(car.ProvinceId);
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CarDao().Delete(id);

            return RedirectToAction("Index");
        }
        public void SetViewBag(long? selectId = null)
        {
            var dao = new ProvinceDao();
            ViewBag.ProvinceID = new SelectList(dao.ListAll(), "ID", "Name", selectId);
        }
        [HttpGet]
        public ActionResult ViewDetail(int id)
        {
            var car = new CarDao().ViewDetail(id);
            ViewBag.carattribute = new CarAttributeDao().ListAll();
            ViewBag.carattributedetail = new CarAttributeDetailDao().ListAll();
            ViewBag.province = new ProvinceDao().ListAll();
            SetViewBag();
            return View(car);
        }
    }
}