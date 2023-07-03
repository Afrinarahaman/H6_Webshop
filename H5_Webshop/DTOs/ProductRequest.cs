

using System.ComponentModel.DataAnnotations;

namespace H5_Webshop.DTOs
{
    public class ProductRequest
    {

        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Stock { get; set; }


        [Required]
        public int CategoryId { get; set; }


    }
}
