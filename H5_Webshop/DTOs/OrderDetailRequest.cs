using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H5_Webshop.DTOs
{
    public class OrderDetailRequest
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }



        public int Quantity { get; set; }


     




       
    }
}
