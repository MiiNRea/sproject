using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class PurchaseOrderView{
        [Key]
        public int purchase_id {get; set;}//PK
   
        public DateTime purchase_date {get; set;}
        
        public List<PurchaseItem> purchase_items {get; set;}


        //public int lotid
    }
}