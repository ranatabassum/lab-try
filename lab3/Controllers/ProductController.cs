using lab3.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab3.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register() { 
            return View();
        }
        [HttpPost]
        public ActionResult Register(Product model)  {
         
            var db = new lab3Entities1();
            db.Products.Add(model);
            
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult List() {
            var db = new lab3Entities1();
            var products = db.Products.ToList();
            return View(products);
        }
        public ActionResult Edit(int id)
        {
            var db = new lab3Entities1();
            var pr= (from p in db.Products
                      where p.ID == id
                      select p).SingleOrDefault();
            return View(pr);
        }
        [HttpPost]
        public ActionResult Edit(Product upProduct)
        {
            var db = new lab3Entities1();
            var exst = (from p in db.Products
                        where p.ID == upProduct.ID
                        select p).SingleOrDefault();
            
            exst.Name = upProduct.Name;
            exst.Price = upProduct.Price;
            exst.qty = upProduct.qty;


            db.Entry(exst).CurrentValues.SetValues(upProduct);
            db.SaveChanges();


           
            return RedirectToAction("List");
        }
        public ActionResult Remove(int id)
        {
            var db = new lab3Entities1();
            var pr = (from p in db.Products
                      where p.ID == id
                      select p).SingleOrDefault();
            return View(pr);
        }
        [HttpPost]
        public ActionResult Remove(Product reProduct)
        {
            var db = new lab3Entities1();
            var exst = (from p in db.Products
                        where p.ID == reProduct.ID
                        select p).SingleOrDefault();
            exst.Name = reProduct.Name;



            db.Entry(exst).CurrentValues.SetValues(reProduct);
            db.SaveChanges();


            db.Products.Remove(exst);
            return RedirectToAction("List");
        }


    }
}