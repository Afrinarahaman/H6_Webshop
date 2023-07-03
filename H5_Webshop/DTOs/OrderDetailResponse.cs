using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H5_Webshop.Database.Entities;

namespace H5_Webshop.DTOs
{
    public class OrderDetailResponse
    {
        public int Id { get; set; }

       
        public int  ProductId{ get; set; }
        public string ProductTitle { get; set; }

        public ProductResponse Product { get; set; }

        public decimal ProductPrice { get; set; }


      
        public int Quantity { get; set; }

       
       




        public OrderResponse Order { get; set; }




    }
  
}
