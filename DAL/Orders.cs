//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int DiscID { get; set; }
        public int StoreID { get; set; }
    
        public virtual Users Users { get; set; }
        public virtual Discs Discs { get; set; }
        public virtual Stores Stores { get; set; }
    }
}
