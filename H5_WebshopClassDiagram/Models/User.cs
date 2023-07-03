
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H5_Webshop.Database.Entities
{
    public class User : Order
    {

        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Telephone { get; set; }

        [Column(TypeName = "nvarchar(128)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(32)")]
        public string Password { get; set; }

        // Role er en enum datatype, der består af integrerede konstanter. Her bruges vi enum for at sætter role(Admin eller Kunder)
        public Role Role { get; set; }
    }

    public enum Role
    {
        Administrator = 0,
        Customer = 1
    }
}
