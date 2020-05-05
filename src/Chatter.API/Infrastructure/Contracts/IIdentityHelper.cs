using CSharpFunctionalExtensions;
using System.Collections.Generic;
using System.Security.Claims;

namespace Chatter.API.Infrastructure.Contracts
{
    public interface IIdentityHelper
    {
        IEnumerable<Claim> GetUserClaims(ClaimsPrincipal user);
        Maybe<int> GetUserIdentifier(ClaimsPrincipal user); 
    }
}
