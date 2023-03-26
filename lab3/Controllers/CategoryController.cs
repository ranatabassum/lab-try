using lab3.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab3.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CatRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CatRegister(Category model)
        {

            var db = new lab3Entities1();
            db.Categorys.Add(model);

            db.SaveChanges();
            return RedirectToAction("CatList");
        }
        public ActionResult CatList()
        {
            var db = new lab3Entities1();
            var categorys = db.Categorys.ToList();
            return View(categorys);
        }
   

/*public ActionResult Edit(int id)
{
    var db = new UMSSp23_CEntities1();
    var ct = (from c in db.Categorys
              where c.Id == id
              select c).SingleOrDefault();
    return View(ct);
}
[HttpPost]
public ActionResult Edit(Category upcategory)
{
    var db = new UMSSp23_CEntities1();
    var exst = (from c in db.Categorys
                where c.Id == upcategory.Id
                select c).SingleOrDefault();
    exst.Name = upstudent.Name;
    

    //db.Entry(exst).CurrentValues.SetValues(upstudent);
    db.SaveChanges();


    //db.Students.Remove(exst);
    return RedirectToAction("CatList");
}*/
    }
}