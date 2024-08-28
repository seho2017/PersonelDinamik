using PersonelDinamik.Models.EntitiyFrameWork;
using PersonelDinamik.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelDinamik.Controllers
{
    [Authorize(Roles = "AB,A")]
    public class DepartmanController : Controller
    {
        PersonelDbEntities db=new PersonelDbEntities();
       
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
        //CRSF
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Departman departman)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmanForm");
            }
            MesajViewModel model = new MesajViewModel();
            if (departman.Id == 0)
            {
                db.Departman.Add(departman);
                model.Mesaj = departman.DepartmanAd + "başarıyla eklendi...";
            }
            else
            {
                var guncellenecekDepartman = db.Departman.Find(departman.Id);
                if (guncellenecekDepartman == null)
                {
                    return HttpNotFound();
                }
                guncellenecekDepartman.DepartmanAd = departman.DepartmanAd;
                model.Mesaj = departman.DepartmanAd + "başarıyla güncellendi...";
            }
           db.SaveChanges();
            model.Status=true;
            model.LinkText = "Departman Listesi";
            model.Url = "/Departman";
            /*return RedirectToAction("Index","Departman");*/
            return View("_Mesaj",model);
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