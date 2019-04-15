using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models {
    public class InventoryInView {
        //p_item_id | lot_id | p_id | qty | po_id | receive date| week-year product
    [Key]
     public int inventoryin_id {get; set;}
    //  2
    //  1 P1 lot3 10
    //  2 P2 lot2 5

    //  order
    //  P1 lot4 5
    //  P2 lot3 6
    public PurchaseOrder purchaseorder {get; set;}
    public int purchase_id {get; set;}
    public ProductInfo productinfo {get; set;}//FK
    public int product_id {get; set;}
    public int inventoryin_qty {get; set;}
    public DateTime manufacturer_date {get; set;}
    public int purchase_type_id {get; set;}
    }
}
