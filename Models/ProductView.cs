using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class ProductView{
        public int product_id {get; set;}
        public string product_name {get; set;}
        public string product_series {get; set;}
        public string product_size {get; set;}

    }
}