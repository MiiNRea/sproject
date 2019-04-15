using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class PActivity{
        [Key]
        public int activity_id{get; set;}
        
        public PurchaseOrderType purchaseordertype {get; set;}//FK
        public int purchase_type_id {get; set;}

        public PurchaseOrder purchaseorder {get; set;}//FK
        public int purchase_id {get; set;}

        public DateTime activity_date {get; set;}
    }
}