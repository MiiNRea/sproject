using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class CustomerOrder{
        //CustomerOrder_id|Customer info [id]|product_id|Customerorder qty|Order_date |p_item_id 
        [Key]
        public int customerOrder_id {get; set;}   
        
        [Display(Name = "Purchase_Date")]//Show in table only
        [DataType(DataType.Date)]     
        public DateTime customerorder_date {get;set;}     
        public int customerorder_qty {get; set;}

        public Inventory Inventory {get; set;}
        public int inventory_id {get; set;}

        public CustomerInfo customerInfo {get; set;}
        public int customerinfo_id {get; set;}

        //public string phone_number {get; set;}
        public int warranty_time {get; set;}
    }
}