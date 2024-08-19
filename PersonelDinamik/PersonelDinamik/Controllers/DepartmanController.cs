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
        PersonelDBEntities2 db=new PersonelDBEntities2(); 
        // GET: Departman
        public ActionResult Index()
        {
            var model=db.Departman.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult yeni()
        {
            
            return View("DepartmanForm");
        }
      [HttpPost]
        public ActionResult Kaydet(Departman departman)
        {
            if (departman.ID == 0)
            {
                db.Departman.Add(departman);
            }
            else
            {
                var guncellenecekDepartman = db.Departman.Find(departman.ID);
                if (guncellenecekDepartman == null)
                {
                    return HttpNotFound();
                }
                guncellenecekDepartman.AD = departman.AD;
            }
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
        public ActionResult Guncelle(int ID) 
        {
            var model = db.Departman.Find(ID);
            if (model == null)
             return HttpNotFound();
                return View("DepartmanForm",model);
            
        }
        
    }
}