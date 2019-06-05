using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{

    public class COReport{

        public int id {get; set;}

        [Display(Name = "Purchase_Date")]//Show in table only
        [DataType(DataType.Date)]  
        public DateTime date{get;set;}     
        public int total {get; set;}

        public string product_id {get;set;}

    }
}