using System.ComponentModel.DataAnnotations;

namespace H5_Webshop.DTOs
{
    public class GuestRequest
    {
      

      
        [Required]
        [StringLength(32, ErrorMessage = "FirstName must be less than 32 chars")]
        public string FirstName { get; set; }

    

        [Required]
        [StringLength(32, ErrorMessage = "LastName must be less than 32 chars")]
        public string LastName { get; set; }
        [Required]
        [StringLength(32, ErrorMessage = "LastName must be less than 100 chars")]
        public string Address { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "LastName must be less than 50 chars")]
        public string Telephone { get; set; }

        [Required]
        [StringLength(128, ErrorMessage = "Email must be less than 128 chars")]
        public string Email { get; set; }
    }
}
