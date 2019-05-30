using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class CustomerOrder{
        //CustomerOrder_id|Customer info [id]|product_id|Customerorder qty|Order_date |p_item_id 
        [Key]
        public int customerorder_id {get; set;}        
        public DateTime customerorder_date {get;set;}     
        public int customerorder_qty {get; set;}
        
        //public List<PurchaseItem> purchase_items {get; set;}
        public ProductInfo productInfo {get; set;}//
        public int product_id {get; set;}

        public CustomerInfo customerInfo {get; set;}//
        public int customerinfo_id {get; set;}
    }
}