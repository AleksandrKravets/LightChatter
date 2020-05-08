using System.ComponentModel.DataAnnotations;

namespace Chatter.Application.DataTransferObjects.Authorization
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
