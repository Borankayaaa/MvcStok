//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLSatislar
    {
        public int Id { get; set; }
        public Nullable<int> Urun { get; set; }
        public Nullable<int> Personel { get; set; }
        public Nullable<int> Musteri { get; set; }
        public Nullable<decimal> Fıyat { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
    
        public virtual TBLMusteri TBLMusteri { get; set; }
        public virtual TBLPersonel TBLPersonel { get; set; }
        public virtual TBLUrunler TBLUrunler { get; set; }
    }
}
