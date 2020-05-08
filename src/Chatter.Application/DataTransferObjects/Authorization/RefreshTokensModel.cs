using System.ComponentModel.DataAnnotations;

namespace Chatter.Application.DataTransferObjects.Authorization
{
    public class RefreshTokensModel
    {
        [Required]
        public string AccessToken { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
