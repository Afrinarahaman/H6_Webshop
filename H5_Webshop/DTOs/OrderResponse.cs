using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H5_Webshop.Database.Entities;

namespace H5_Webshop.DTOs
{
    public class OrderResponse
    {
        public int Id { get; set; }

       
        public DateTime OrderDate { get; set; }

       
        public int UserId { get; set; }

       
        public UserResponse User { get; set; }
        public List<OrderDetailResponse> OrderDetails { get; set; } = new();

    }
   
}
