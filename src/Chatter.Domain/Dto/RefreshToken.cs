using System;

namespace Chatter.Domain.Dto
{
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
