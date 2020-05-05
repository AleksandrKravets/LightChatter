using System;

namespace Chatter.Domain.Dto
{
    public sealed class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
