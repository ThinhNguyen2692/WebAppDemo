using System.ComponentModel.DataAnnotations;

namespace WebAppDemo.Models
{
    public class LoginRequest
    {
        [Required]
        public string EmailAddres { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
