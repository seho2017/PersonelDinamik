//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonelDinamik.Models.EntitiyFrameWork
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personel
    {
        public int ID { get; set; }
        public int DEPARTMANID { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public Nullable<byte> YAS { get; set; }
        public Nullable<short> MAAS { get; set; }
        public Nullable<System.DateTime> DOGUMTARIHI { get; set; }
        public Nullable<bool> CINSIYET { get; set; }
        public Nullable<bool> EVLIMI { get; set; }
    
        public virtual Departman Departman { get; set; }
    }
}
