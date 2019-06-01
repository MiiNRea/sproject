using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    
    public class Warranty{
        [Key]
        public int warranty_id {get;set;}
        public CustomerOrder customerOrder {get; set;}
        public int customerOrder_id {get; set;}
        public string problem {get; set;}
        public DateTime claim_date {get; set;}        
    }
}