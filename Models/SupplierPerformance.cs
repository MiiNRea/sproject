using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class SupplierPerformance{
        [Key]
        public int SupplierPerformance_id {get; set;}
        

        public PurchaseOrder purchaseOrder {get; set;}//FK
        public int purchase_id {get;set;}//Product, Date
        
        
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime deliver_date {get; set;}

        public int leadTime {get; set;}
        public int backorder {get; set;}

    }
}