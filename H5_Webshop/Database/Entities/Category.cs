using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H5_Webshop.DTOs.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string? CategoryName { get; set; }


        public List<Product> Products { get; set; } = new();
    }
}
