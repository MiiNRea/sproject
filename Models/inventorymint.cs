using System;

namespace sproject.Models{
    public class inventorymint{
        public string product_name {get; set;}
        public string supplier_name {get; set;}

        public DateTime completeDate {get; set;}

        public int product_qty {get; set;}
        public double total {get; set;}
        public string status {get; set;}
    }
}