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
    
    public partial class TBLPERSONEL
    {
        public int PERSONELID { get; set; }
        public string ADSOYAD { get; set; }
        public string TC { get; set; }
        public string ADRES { get; set; }
        public string TELEFON { get; set; }
        public string MAIL { get; set; }
        public Nullable<System.DateTime> ISEGIRISTARIH { get; set; }
        public Nullable<System.DateTime> ISCIKISTARIH { get; set; }
        public Nullable<int> DEPARTMAN { get; set; }
        public Nullable<int> GOREV { get; set; }
        public string ACIKLAMA { get; set; }
        public Nullable<int> DURUM { get; set; }
        public string KIMLIKON { get; set; }
        public string KIMLIKARKA { get; set; }
        public string SIFRE { get; set; }
        public string YETKI { get; set; }
    
        public virtual TBLDEPARTMAN TBLDEPARTMAN { get; set; }
        public virtual TBLDURUM TBLDURUM { get; set; }
        public virtual TBLGOREV TBLGOREV { get; set; }
    }
}
