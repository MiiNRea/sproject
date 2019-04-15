using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class ProductInfo{
        [Key]
        public int product_id {get; set;} //PK

        [Required]
        public string product_name {get; set;}

        [Required]
        public string product_series {get; set;}
        
        [Required]
        public string product_size {get; set;}
    }
}