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
        public byte YAS { get; set; }
        public short MAAS { get; set; }
        public System.DateTime DOGUMTARIHI { get; set; }
        public bool CINSIYET { get; set; }
        public bool EVLIMI { get; set; }
    
        public virtual Departman Departman { get; set; }
    }
}
