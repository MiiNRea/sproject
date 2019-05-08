using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class PurchaseOrder{
        [Key]
        public int purchase_id {get; set;}//PK
        
        [Display(Name = "Purchase_Date")]//Show in table only
        [DataType(DataType.Date)]
        public DateTime purchase_date {get; set;}
        
        public List<PurchaseItem> purchase_items {get; set;}


        //public int lotid
    }
}