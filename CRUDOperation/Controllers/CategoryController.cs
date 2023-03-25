using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDOperation.Controllers
{
    public class CategoryController : Controller
    {
        CRUDDBContexts contexts = new CRUDDBContexts();
        public ActionResult Index()
        {
            var listofData1 = contexts.Categories.ToList();
            return View(listofData1);
           
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            contexts.Categories.Add(model);
            contexts.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = contexts.Categories.Where(x => x.CategoryId == id).FirstOrDefault();

            return View(data);
        }
        [HttpPost]

        public ActionResult Detail(int id)
        {
            var data = contexts.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Edit(Category Model)
        {
            var data = contexts.Categories.Where(x => x.CategoryId == Model.CategoryId).FirstOrDefault();
            if (data != null)
            {
                data.CategoryName = Model.CategoryName;
                contexts.SaveChanges();
            }
            return RedirectToAction("Index");
        }



        public ActionResult Delete(int id)
        {
            var data = contexts.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            contexts.Categories.Remove(data);
            contexts.SaveChanges();
            ViewBag.Message = "Record Delete Sucessfully";
            return RedirectToAction("Index");
        }

    }
}
