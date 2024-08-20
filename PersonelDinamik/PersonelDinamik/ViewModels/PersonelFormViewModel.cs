using PersonelDinamik.Models.EntitiyFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelDinamik.ViewModels
{
    public class PersonelFormViewModel
    {
        public IEnumerable<Departman> Departmanlar { get;set; }
        public Personel personel { get;set; }
    }
}