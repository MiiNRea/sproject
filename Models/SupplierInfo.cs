using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class SupplierInfo{
        [Key]
        public int supplier_id {get; set;} //PK
        
        [Required]
        public string supplier_name {get; set;}
        public string supplier_person {get; set;}

        //[RegularExpression(@"\(?[0-9]{3}\)?-[0-9]{3}-[0-9]{4}", ErrorMessage = "Putin format XXX-XXX-XXXX.")]
        //[Required]
        public string supplier_phone {get; set;}
        public string supplier_address {get; set;}

        [Required]
        public SupplierType supplier_type {get; set;}
        public int supplier_type_id {get; set;} //partner,supplier

        public ProductInfo productInfo {get; set;} //FK
        public int product_id {get; set;}
    }
}