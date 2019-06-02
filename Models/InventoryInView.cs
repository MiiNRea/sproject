using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models {
    public class InventoryInView {
       
     public int inventoryin_id {get; set;}
    
    public PurchaseOrder purchaseorder {get; set;}
    public int purchase_id {get; set;}
    
    public ProductInfo productinfo {get; set;}//FK
    public int product_id {get; set;}

    public int inventoryin_qty {get; set;}
    
    public int manufacturer_week {get; set;}
    public int manufacturer_year {get; set;}

    public PurchaseItem purchaseItem {get; set;}
    public int purchaseItem_id {get; set;}

    public int purchase_type_id {get; set;}

    public SupplierInfo supplierInfo {get; set;}
    public int supplier_id {get; set;}
    }
}
