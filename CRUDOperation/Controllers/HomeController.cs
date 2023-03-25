using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDOperation.Controllers
{
    public class HomeController : Controller
    {
        CRUDDBContext _context = new CRUDDBContext();
        public ActionResult Index()
        {
            var listofData = _context.Products.ToList();
            return View(listofData);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product model)
        {
            _context.Products.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Insert Successfully";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]

        public ActionResult Detail(int id)
        {
            var data = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Edit(Product Model)
        {
            var data = _context.Products.Where(x => x.ProductId == Model.ProductId).FirstOrDefault();
            if (data != null)
            {
                data.ProductName = Model.ProductName;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

       
        
        public ActionResult Delete(int id)
        {
            var data = _context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            _context.Products.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Delete Sucessfully";
            return RedirectToAction("Index");
        }
       
    }
}