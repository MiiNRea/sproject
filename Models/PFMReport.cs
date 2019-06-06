using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{

    public class PFMReport{

        public DateTime date{get;set;}   

        public string supplier_name {get; set;}  

        public int leadtime {get; set;}

        public int backorder{get;set;}
        public int total {get; set;}


    }
}