using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class BackOrder{
        [Key]
        public  int backOrder_id {get;set;}

        public PurchaseItem purchaseItem{get; set;}
        public int purchaseItem_id {get; set;}

    }
}