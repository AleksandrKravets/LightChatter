using System.Collections.Generic;

namespace Chatter.Application.DataTransferObjects.Authorization
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Success { get; set; }

        public static AuthenticationResult Failed()
        {
            return new AuthenticationResult
            {
                Success = false
            };
        }
    }
}
