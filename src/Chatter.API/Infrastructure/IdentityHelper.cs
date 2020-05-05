using Chatter.API.Infrastructure.Contracts;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using Chatter.Application.Infrastructure;

namespace Chatter.API.Infrastructure
{
    public class IdentityHelper : IIdentityHelper
    {
        public IEnumerable<Claim> GetUserClaims(ClaimsPrincipal user)
        {
            return user.Claims;
        }

        public Maybe<int> GetUserIdentifier(ClaimsPrincipal user)
        {
            return Maybe<int>.From(Convert.ToInt32(user.Claims
                .Where(x => x.Type == Constants.CustomClaims.UserIdentifier)
                .FirstOrDefault().Value));
        }
    }
}
