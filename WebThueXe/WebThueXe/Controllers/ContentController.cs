using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebThueXe.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index(string searchString, int page = 1, int pageSize = 7)
        {
            var contentDao = new ContentDao();
            var model = new ContentDao().ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            ViewBag.ListCategory = new CategoryDao().ListAll();
            ViewBag.ListNewContents = contentDao.ListNewContent(4);
            ViewBag.ListAllTag = new TagDao().ListAll();
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            var model = new ContentDao().ViewDetail(id);
            var contentDao = new ContentDao();
            ViewBag.ListAllTag = new TagDao().ListAll();
            ViewBag.Tags = new ContentDao().ListTag(id);
            ViewBag.ListCategory = new CategoryDao().ListAll();
            ViewBag.comment = new ContentReviewDao().ListByCategoryId(id);
            ViewBag.ListNewContents = contentDao.ListNewContent(4);
            return View(model);
        }
       
    }
}