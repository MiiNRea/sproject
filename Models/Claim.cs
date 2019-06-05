using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    
    public class Claim{
        [Key]
        public int claim_id {get;set;}
        public CustomerOrder customerOrder {get; set;}
        public int customerOrder_id {get; set;}
        public string problem {get; set;}
        [Display(Name = "Purchase_Date")]//Show in table only
        [DataType(DataType.Date)]
        public DateTime claim_date {get; set;} 

        public CustomerInfo customerInfo{get; set;}     
        public int customerinfo_id {get; set;}
    }
}