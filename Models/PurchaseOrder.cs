using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class PurchaseOrder{
        [Key]
        public int purchase_id {get; set;}//PK
        
        [Display(Name = "Purchase_Date")]//Show in table only
        [DataType(DataType.Date)]
        public DateTime purchase_date {get; set;}
        
        public int purchase_item {get; set;}

        [Required]
        public double purchase_cost {get; set;} //total

        public PurchaseOrderType purchaseorder_type {get; set;}
        public int purchase_type_id {get; set;} //partner,supplier
        
        public ProductInfo productInfo {get; set;}//FK
        public int product_id {get; set;}
        
        public SupplierInfo supplierInfo {get; set;}//FK
        public int supplier_id {get; set;}
    }
}