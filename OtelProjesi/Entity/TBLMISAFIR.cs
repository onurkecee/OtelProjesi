//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OtelProjesi.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLMISAFIR
    {
        public int MISAFIRID { get; set; }
        public string ADSOYAD { get; set; }
        public string TC { get; set; }
        public string MAIL { get; set; }
        public string TELEFON { get; set; }
        public string ADRES { get; set; }
        public string ACIKLAMA { get; set; }
        public string KIMLIKFOTO1 { get; set; }
        public string KIMLIKFOTO2 { get; set; }
        public Nullable<int> ULKE { get; set; }
        public Nullable<int> DURUM { get; set; }
        public Nullable<int> SEHIR { get; set; }
        public Nullable<int> ILCE { get; set; }
    
        public virtual TBLDURUM TBLDURUM { get; set; }
        public virtual ilceler ilceler { get; set; }
        public virtual iller iller { get; set; }
    }
}
