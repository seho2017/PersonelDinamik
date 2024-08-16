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
        public ActionResult yeni()
        {
            return View();
        }
    }
}