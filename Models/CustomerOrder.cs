using System.ComponentModel.DataAnnotations;

namespace sproject.Models{
    public class CustomerOrder{
        //CustomerOrder_id|Customer info [id]|product_id|Customerorder qty|Order_date |p_item_id 
        [Key]
        public int customerOrder_id {get; set;}



        public ProductInfo ProductInfo {get; set;}
        public int product_id {get; set;}

        public CustomerInfo CustomerInfo {get; set;}
        public int customerInfo_id {get; set;}

    }
}