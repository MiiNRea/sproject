using System;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class Inventory{
        [Key]
        public int inventory_id {get; set;} //PK

        public ProductInfo productInfo {get; set;}//FK
        public int product_id {get; set;} 

        public string product_name {get; set;}

        public int invento_qty {get; set;}
   
    }
}