using System;

namespace Chatter.Application.DataTransferObjects.Tokens
{
    public class RefreshTokenDto
    {
        public string Token { get; set; }
        public string JwtId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public long UserId { get; set; }
    }
}
