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
    
    public partial class TBLTELEFON
    {
        public int TELEFONID { get; set; }
        public string ACIKLAMA { get; set; }
        public string TELEFON { get; set; }
        public Nullable<int> DURUM { get; set; }
    
        public virtual TBLDURUM TBLDURUM { get; set; }
    }
}