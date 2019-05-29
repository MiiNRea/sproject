using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class SupplierPerformance{
        [Key]
        public int SupplierPerformance_id {get; set;}
        
        public SupplierInfo supplierInfo {get; set;}
        public int supplier_id {get; set;}

        public PurchaseOrder purchaseOrder {get; set;}//FK
        public int purchase_id {get;set;}//Product, Date

        public PurchaseItem purchaseItem{get; set;}
        public int purchaseItem_id {get; set;}

                        
        // [Display(Name = "Release Date")]
        // [DataType(DataType.Date)]
        public DateTime deliver_date {get; set;}
        public int leadTime {get; set;}
        public BackOrder backOrder {get; set;}
        public int backOrder_id {get; set;}

    }
}