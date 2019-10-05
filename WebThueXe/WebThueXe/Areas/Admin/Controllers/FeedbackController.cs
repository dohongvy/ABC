using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebThueXe.Areas.Admin.Controllers
{
    public class FeedbackController : BaseController
    {
        // GET: Admin/Feedback
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new FeedbackDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ContentDao().Delete(id);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var feedback = new FeedbackDao().ViewDetail(id);
            return View(feedback);
        }
        [HttpPost]
        public ActionResult Edit(Feedback category)
        {
            if (ModelState.IsValid)
            {
                var dao = new FeedbackDao();
                var result = dao.Update(category);
                if (result)
                {
                    SetAlert("Cập nhật thông báo thành công", "success");
                    return RedirectToAction("Index", "Feedback");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thông báo không thành công");
                }
            }
            return View("Index");
        }

    }
}