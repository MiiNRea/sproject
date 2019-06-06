using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    
    public class TopSupplier{        
        [Key]
        public int Top_id {get;set;}
        public string product_name {get; set;} 
        public int leadTime {get; set;}    
        public int backOrder {get; set;}
    }
}