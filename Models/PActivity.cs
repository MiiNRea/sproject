using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class PActivity{
        [Key]
        public int activity_id{get; set;}
        
        public PurchaseOrderType purchaseordertype {get; set;}//FK
        public int purchase_type_id {get; set;}

        public PurchaseItem purchaseItem {get; set;}//FK
        public int purchaseItem_id {get; set;}

        public DateTime activity_date {get; set;}
    }
}