using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class ProductView{
        public int purchase_id {get; set;}
        public List<PurchaseItemView> purchaseItems {get; set;}
    }
}
