using System;
using System.Collections.Generic;

namespace sproject.Models{
    public class PurchaseDetailView{
        public int purchase_id {get; set;}
        public DateTime purchase_date {get; set;}
        
        public List<PurchaseItemDetailView> purchaseItems {get; set;}
    }
}