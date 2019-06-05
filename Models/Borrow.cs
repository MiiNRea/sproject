using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class Borrow{
        [Key]
        public int borrow_id {get; set;}
        public SupplierInfo supplierInfo {get; set;} //show only partner
        public int supplier_id {get;set;}
        public ProductInfo productInfo {get; set;}
        public int product_id {get; set;}
        
        public int borrow_qty {get; set;}

        [Display(Name = "Purchase_Date")]//Show in table only
        [DataType(DataType.Date)]  
        public DateTime borrow_date {get; set;}   

        public PurchaseOrder purchaseOrder{get; set;}  
        public int purchase_id {get;set;}
    }
}