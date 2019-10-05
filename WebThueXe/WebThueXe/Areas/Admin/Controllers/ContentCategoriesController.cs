using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebThueXe.Areas.Admin.Controllers
{
    public class ContentCategoriesController : BaseController
    {
        // GET: Admin/ContentCategory
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new CategoryDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                long id = dao.Insert(category);
                if (id > 0)
                {
                    SetAlert("Thêm danh mục thành công", "success");
                    return RedirectToAction("Index", "ContentCategories");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm danh mục không thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Edit(int id)
        {
            var category = new CategoryDao().ViewDetail(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Update(category);
                if (result)
                {
                    SetAlert("Cập nhật danh mục thành công", "success");
                    return RedirectToAction("Index", "ContentCategories");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật danh mục không thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CategoryDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}