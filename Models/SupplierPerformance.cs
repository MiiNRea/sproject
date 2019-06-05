using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class SupplierPerformance{
        [Key]
        public int SupplierPerformance_id {get; set;}
        
        public SupplierInfo supplierInfo {get; set;}
        public int supplier_id {get; set;}

        public PurchaseItem purchaseItem{get; set;}
        public int purchaseItem_id {get; set;}
        [Display(Name = "Purchase_Date")]//Show in table only
        [DataType(DataType.Date)]
        public DateTime deliver_date {get; set;}
        public int leadTime {get; set;}
        public int backOrder {get; set;}
    }
}