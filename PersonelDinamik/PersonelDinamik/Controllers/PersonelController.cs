using PersonelDinamik.Models.EntitiyFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersonelDinamik.ViewModels;

namespace PersonelDinamik.Controllers
{
    [Authorize(Roles = "AB,A")]
    public class PersonelController : Controller
    {
        PersonelDbEntities db=new PersonelDbEntities();
        // GET: Personel
        [OutputCache(Duration =30)]
        public ActionResult Index()
        {
            var model=db.Personel.Include(x=>x.Departman).ToList();
            return View(model);
        }
        
        public ActionResult yeni() 
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                 personel = new Personel()
            };
            return View("PersonelForm",model);
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Personel personel)
        {
            if (!ModelState.IsValid) {
                var model = new PersonelFormViewModel()

                {
                    Departmanlar=db.Departman.ToList(),
                   personel = personel
                };
                return View("PersonelForm",model);
            }
            if(personel.Id==0)//ekleme işlemi
            {
                db.Personel.Add(personel);
            }
            else//güncelleme
            {
                db.Entry(personel).State = System.Data.Entity.EntityState.Modified;

            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(int id)
        {
            var model = new PersonelFormViewModel()
            {
                Departmanlar = db.Departman.ToList(),
                personel = db.Personel.Find(id)
            };
            return View("PersonelForm", model);
        }
        public ActionResult Sil(int id)
        {
            var silinecekPersonel = db.Personel.Find(id);
            if (silinecekPersonel == null)
            {
                return HttpNotFound();
            }
            db.Personel.Remove(silinecekPersonel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelleriListele(int id)
        {
            var model=db.Personel.Where(x=>x.DepartmanId==id).ToList();
            return PartialView(model);
        }
       /* public int? ToplamMaas()
        {
            return db.Personel.Sum(x=>x.Maas);
        }*/
       public ActionResult ToplamMaas()
        {
            ViewBag.Maas=db.Personel.Sum(x=>x.Maas);
            return PartialView();
        }
    }
}