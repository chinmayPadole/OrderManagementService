//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderManagementService.Data.Models.Order
{
    using System;
    using System.Collections.Generic;
    
    public partial class tItem
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> AmountWithoutTax { get; set; }
    
        public virtual tOrder tOrder { get; set; }
    }
}
