using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class CustomerInfo{
        [Key]
        public int customerInfo_id {get; set;}

        [Required]
        public string customer_name {get; set;}
        
        //[RegularExpression(@"\(?[0-9]{3}\)?-?[0-9]{3}-?[0-9]{4}", ErrorMessage = "Putin format XXX-XXX-XXXX.")]
        [Required]
        public string customer_phone {get; set;}
    }
}