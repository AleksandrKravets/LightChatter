using System;

namespace Chatter.Application.DataTransferObjects.Tokens
{
    public class RefreshTokenModel
    {
        public string Token { get; set; }
        public string JwtId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool Used { get; set; }
        public long UserId { get; set; }
    }
}
