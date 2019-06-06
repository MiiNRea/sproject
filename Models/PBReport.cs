using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    
    public class PBReport{
        [Key]
        public int claim_id {get;set;}
        public int customerOrder_id {get; set;}
        public string product_name {get; set;}
        public string customer_name {get; set;}
        public string problem {get; set;}

        [Display(Name = "Purchase_Date")]//Show in table only
        [DataType(DataType.Date)]
        public DateTime claim_date {get; set;} 
 
    }
}