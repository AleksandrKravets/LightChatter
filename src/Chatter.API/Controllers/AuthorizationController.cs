using Microsoft.AspNetCore.Mvc;

namespace Chatter.WebUI.Controllers
{
    [Route("api/authorization/")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        //private readonly IAuthorizationService _authorizationService;
        //private readonly ITokenService _tokenService;

        //public AuthorizationController(
        //    IAuthorizationService authorizationService,
        //    ITokenService tokenService)
        //{
        //    _authorizationService = authorizationService;
        //    _tokenService = tokenService;
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login([FromBody]LoginRequestModel model)
        //{
        //    return Ok(await _authorizationService.AuthorizeAsync(model));
        //}

        //[HttpPost]
        //public async Task<IActionResult> RefreshToken([FromBody]RefreshTokenRequestModel model)
        //{
        //    return Ok(await _tokenService.RefreshTokenAsync(model.RefreshToken, model.AccessToken));
        //}

        //[Authorize]
        //[HttpGet]
        //public IActionResult Secret()
        //{
        //    return Ok();
        //}








        //public class JwtSettings
        //{
        //    public string Secret { get; set; }
        //    public TimeSpan TokenLifetime { get; set; }
        //}

        //private readonly JwtSettings _jwtSettings;
        //private readonly TokenValidationParameters _tokenValidationParameters;


        //[HttpPost(ApiRoutes.Identity.Register)]
        //public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(new AuthFailedResponse
        //        {
        //            Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
        //        });
        //    }

        //    var authResponse = await RegisterAsync(request.Email, request.Password);

        //    if (!authResponse.Success)
        //    {
        //        return BadRequest(new AuthFailedResponse
        //        {
        //            Errors = authResponse.Errors
        //        });
        //    }

        //    return Ok(new AuthSuccessResponse
        //    {
        //        Token = authResponse.Token,
        //        RefreshToken = authResponse.RefreshToken
        //    });
        //}

        //[HttpPost(ApiRoutes.Identity.Login)]
        //public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        //{
        //    var authResponse = await LoginAsync(request.Email, request.Password);

        //    if (!authResponse.Success)
        //    {
        //        return BadRequest(new AuthFailedResponse
        //        {
        //            Errors = authResponse.Errors
        //        });
        //    }

        //    return Ok(new AuthSuccessResponse
        //    {
        //        Token = authResponse.Token,
        //        RefreshToken = authResponse.RefreshToken
        //    });
        //}

        //[HttpPost(ApiRoutes.Identity.Refresh)]
        //public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest request)
        //{
        //    var authResponse = await RefreshTokenAsync(request.Token, request.RefreshToken);

        //    if (!authResponse.Success)
        //    {
        //        return BadRequest(new AuthFailedResponse
        //        {
        //            Errors = authResponse.Errors
        //        });
        //    }

        //    return Ok(new AuthSuccessResponse
        //    {
        //        Token = authResponse.Token,
        //        RefreshToken = authResponse.RefreshToken
        //    });
        //}

        //public async Task<AuthenticationResult> RegisterAsync(string email, string password)
        //{
        //    // get user by email
        //    var existingUser = new User();

        //    if (existingUser != null)
        //    {
        //        return new AuthenticationResult
        //        {
        //            Errors = new[] { "User with this email address already exists" }
        //        };
        //    }

        //    var newUser = new User
        //    {
        //        Email = email,
        //    };

        //    // call prodecure to create user

        //    //if (!createdUser.Succeeded)
        //    //{
        //    //    return new AuthenticationResult
        //    //    {
        //    //        Errors = createdUser.Errors.Select(x => x.Description)
        //    //    };
        //    //}

        //    return await GenerateAuthenticationResultForUserAsync(newUser);
        //}

        //public async Task<AuthenticationResult> LoginAsync(string email, string password)
        //{
        //    // get user by email
        //    var user = new User();

        //    if (user == null)
        //    {
        //        return new AuthenticationResult
        //        {
        //            Errors = new[] { "User does not exist" }
        //        };
        //    }

        //    // check user password
        //    var userHasValidPassword = true;

        //    if (!userHasValidPassword)
        //    {
        //        return new AuthenticationResult
        //        {
        //            Errors = new[] { "User/password combination is wrong" }
        //        };
        //    }

        //    return await GenerateAuthenticationResultForUserAsync(user);
        //}

        //public async Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken)
        //{
        //    var validatedToken = GetPrincipalFromToken(token);

        //    if (validatedToken == null)
        //    {
        //        return new AuthenticationResult { Errors = new[] { "Invalid Token" } };
        //    }

        //    var expiryDateUnix =
        //        long.Parse(validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

        //    var expiryDateTimeUtc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        //        .AddSeconds(expiryDateUnix);

        //    if (expiryDateTimeUtc > DateTime.UtcNow)
        //    {
        //        return new AuthenticationResult { Errors = new[] { "This token hasn't expired yet" } };
        //    }

        //    var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

        //    // Get token from db (x.Token == refreshToken)
        //    var storedRefreshToken = new RefreshToken();

        //    if (storedRefreshToken == null)
        //    {
        //        return new AuthenticationResult { Errors = new[] { "This refresh token does not exist" } };
        //    }

        //    if (DateTime.UtcNow > storedRefreshToken.ExpiryDate)
        //    {
        //        return new AuthenticationResult { Errors = new[] { "This refresh token has expired" } };
        //    }

        //    if (storedRefreshToken.Invalidated)
        //    {
        //        return new AuthenticationResult { Errors = new[] { "This refresh token has been invalidated" } };
        //    }

        //    if (storedRefreshToken.Used)
        //    {
        //        return new AuthenticationResult { Errors = new[] { "This refresh token has been used" } };
        //    }

        //    if (storedRefreshToken.JwtId != jti)
        //    {
        //        return new AuthenticationResult { Errors = new[] { "This refresh token does not match this JWT" } };
        //    }

        //    // storedRefreshToken.Used = true; call sp to use refresh token

        //    var user = new User(); // get user using id from claims validatedToken.Claims.Single(x => x.Type == "id").Value
        //    return await GenerateAuthenticationResultForUserAsync(user);
        //}

        //private ClaimsPrincipal GetPrincipalFromToken(string token)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    try
        //    {
        //        var tokenValidationParameters = _tokenValidationParameters.Clone();
        //        tokenValidationParameters.ValidateLifetime = false;
        //        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
        //        if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
        //        {
        //            return null;
        //        }

        //        return principal;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        //{
        //    return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
        //           jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
        //               StringComparison.InvariantCultureIgnoreCase);
        //}

        //private async Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(User user)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

        //    var claims = new List<Claim>
        //    {
        //        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        //        new Claim("id", user.Id.ToString())
        //    };

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = DateTime.UtcNow.Add(_jwtSettings.TokenLifetime),
        //        SigningCredentials =
        //            new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    var token = tokenHandler.CreateToken(tokenDescriptor);

        //    var refreshToken = new RefreshToken
        //    {
        //        JwtId = token.Id,
        //        UserId = user.Id,
        //        CreationDate = DateTime.UtcNow,
        //        ExpiryDate = DateTime.UtcNow.AddMonths(6)
        //    };

        //    // call sp to create refresh token

        //    return new AuthenticationResult
        //    {
        //        Success = true,
        //        Token = tokenHandler.WriteToken(token),
        //        RefreshToken = refreshToken.Token
        //    };
        //}

        //public class AuthenticationResult
        //{
        //    public string Token { get; set; }
        //    public string RefreshToken { get; set; }
        //    public bool Success { get; set; }
        //    public IEnumerable<string> Errors { get; set; }
        //}

        //public class RefreshToken
        //{
        //    [Key]
        //    public string Token { get; set; }
        //    public string JwtId { get; set; }
        //    public DateTime CreationDate { get; set; }
        //    public DateTime ExpiryDate { get; set; }
        //    public bool Used { get; set; }
        //    public bool Invalidated { get; set; }
        //    public int UserId { get; set; }
        //}
    }
}
