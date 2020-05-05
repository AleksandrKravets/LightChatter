using System.Collections.Generic;

namespace Chatter.Domain.Dto.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
