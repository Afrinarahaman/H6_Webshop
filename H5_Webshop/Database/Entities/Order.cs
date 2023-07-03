using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace H5_Webshop.Database.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Date")]  //this is a columnAttribute from System.CoponentModel.DataAnnotations (defined in enityframework.dll)
        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public List<OrderDetails> OrderDetails { get; set; } = new();
    }
}
