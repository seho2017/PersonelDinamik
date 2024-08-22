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
        PersonelDbEntities db=new PersonelDbEntities();
        // GET: Departman
        public ActionResult Index()
        {
            var model=db.Departman.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult yeni()
        {
            
            return View("DepartmanForm",new Departman());
        }
      [HttpPost]
        public ActionResult Kaydet(Departman departman)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanForm");
            }
            if (departman.Id == 0)
            {
                db.Departman.Add(departman);
            }
            else
            {
                var guncellenecekDepartman = db.Departman.Find(departman.Id);
                if (guncellenecekDepartman == null)
                {
                    return HttpNotFound();
                }
                guncellenecekDepartman.DepartmanAd = departman.DepartmanAd;
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