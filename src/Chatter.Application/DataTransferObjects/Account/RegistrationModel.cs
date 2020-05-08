using System.ComponentModel.DataAnnotations;

namespace Chatter.Application.DataTransferObjects.Account
{
    public class RegistrationModel
    {
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
