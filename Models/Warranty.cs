using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    
    public class Warranty{
        [Key]
        public int warranty_id {get;set;}
        public string problem {get; set;}
        public DateTime claim_date {get; set;}
        
    }
}