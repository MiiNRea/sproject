using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class PurchaseOrderType{
        [Key]
        public int Purchase_type_id {get;set;}
        public string Purchase_type_name {get; set;}
        
    }
}