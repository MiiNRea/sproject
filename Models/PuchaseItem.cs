using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class PurchaseItem{
        [Key]
        public int purchaseItem_id {get; set;}
        
   
        public double purchase_cost {get; set;} //total

        public PurchaseOrderType purchaseorder_type {get; set;}
        public int purchase_type_id {get; set;} 
        
        public ProductInfo productInfo {get; set;}//FK
        public int product_id {get; set;}

        public int qty {get; set;}
        
        public double selling_price {get; set;}
        //reverse NP
        public int purchase_id {get; set;}//PK
        public SupplierInfo supplierInfo {get; set;}//FK
        public int supplier_id {get; set;}
    }
}