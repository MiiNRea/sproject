using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class BackOrder{
        //PO_id|Product_id|qty|totalcost| date |Status: done/in process| supplier
        [Key]
        public int backOrder_id {get; set;}
        
        public DateTime backOrderDate {get; set;}
        
        
        public PurchaseItem purchaseItem {get; set;}
        public int purchaseItem_id {get; set;}

        public ProductInfo productInfo {get; set;}
        public int Product_id {get; set;}

        // public BackOrderStatus backOrderStatus {get; set;}
        // public int backOrderStatus_id {get; set;}
    }
}