using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H5_Webshop.DTOs.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Title { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Image { get; set; }

        [Column(TypeName = "smallint")]
        public int Stock { get; set; }


        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
