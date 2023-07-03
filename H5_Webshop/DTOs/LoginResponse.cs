using H5_Webshop.Helpers;

namespace H5_Webshop.DTOs
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
       
        public Role Role { get; set; }
        public string Token { get; set; }
    }
}
