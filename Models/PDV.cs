using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class PDV{
        public int purchase_id {get; set;}

        [Display(Name = "Purchase_Date")]//Show in table only
        [DataType(DataType.Date)]
        public DateTime purchase_date {get; set;}
        
        public List<PurchaseItemDetailView> purchaseItems {get; set;}
    }
}