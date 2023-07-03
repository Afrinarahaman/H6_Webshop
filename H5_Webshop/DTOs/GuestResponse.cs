using H5_Webshop.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace H5_Webshop.DTOs
{
    public class GuestResponse
    {
        public int Id { get; set; }
        
       
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
        
        public string Address { get; set; }

       
        public string Telephone { get; set; }
        public string Email { get; set; }

        public Role Role { get; set; }
    }
}
