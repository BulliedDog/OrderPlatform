//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderPlatform
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductOrder
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public decimal total_price { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
