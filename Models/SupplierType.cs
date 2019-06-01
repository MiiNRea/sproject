using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    
    public class SupplierType{
        [Key]
        public int supplier_type_id {get;set;}
        public string supplier_type_name {get; set;}        
    }
}