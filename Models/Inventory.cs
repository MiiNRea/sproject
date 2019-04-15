using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class Inventory{
        [Key]
        public int inventory_id {get; set;} //PK

        public ProductInfo productInfo {get; set;}//FK
        public int product_id {get; set;} 

        //qty ---> |lot|week-year product|

       // public InventoryQty inventoryQty {get; set;}//FK
       // public int inventoryQty_id {get; set;}
   
    }
}