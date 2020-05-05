using System.ComponentModel.DataAnnotations;

namespace Chatter.Domain.Dto
{
    public class RefreshTokenRequestModel
    {
        [Required]
        public string AccessToken { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
