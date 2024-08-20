using PersonelDinamik.Models.EntitiyFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PersonelDinamik.Controllers
{
    public class PersonelController : Controller
    {
        PersonelDbEntities db=new PersonelDbEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var model=db.Personel.Include(x=>x.Departman).ToList();
            return View(model);
        }
        public ActionResult yeni() 
        {
            return View("PersonelForm");
        }
    }
}