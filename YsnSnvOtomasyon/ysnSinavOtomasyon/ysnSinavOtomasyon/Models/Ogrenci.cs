//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ysnSinavOtomasyon.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ogrenci
    {
        public Ogrenci()
        {
            this.SinavListe = new HashSet<SinavListe>();
        }
    
        public int OgrenciId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int No { get; set; }
    
        public virtual ICollection<SinavListe> SinavListe { get; set; }
    }
}
