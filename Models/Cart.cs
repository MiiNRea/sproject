using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sproject.Models{


    public class Cart{
        public int      purchase_type_id      {get;set;}
        public List<CartItem> items            {get;set;}
        
    }//ec
}//en