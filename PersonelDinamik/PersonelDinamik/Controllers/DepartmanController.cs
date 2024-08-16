using PersonelDinamik.Models.EntitiyFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelDinamik.Controllers
{
    public class DepartmanController : Controller
    {
        PersonelDBEntities db=new PersonelDBEntities(); 
        // GET: Departman
        public ActionResult Index()
        {
            var model=db.Departman.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult yeni()
        {
            
            return View();
        }
      [HttpPost]
        public ActionResult yeni(Departman departman)
        {
            db.Departman.Add(departman);
            db.SaveChanges();
           return RedirectToAction("Index","Departman");
        }
        public ActionResult Sil(int id)
        {
            var silinecekDepartman = db.Departman.Find(id);
            if (silinecekDepartman == null)
                return HttpNotFound();
            db.Departman.Remove(silinecekDepartman);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        
    }
}