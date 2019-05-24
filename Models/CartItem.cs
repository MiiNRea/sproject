using System.ComponentModel.DataAnnotations;

namespace sproject.Models{


    public class CartItem{
        public int      id          {get;set;}
        public int   supplier_id    {get;set;}
        public string   name        {get;set;}
        public double   price       {get;set;}
        public int      qty         {get;set;}
        public double   total       {get;set;}    
        
    }//ec
}//en