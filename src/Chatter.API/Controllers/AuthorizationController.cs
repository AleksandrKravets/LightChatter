using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/authorization")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly IAuthService _authorizationService;

        public AuthorizationController(IAuthService authorizationService)
        {
            _authorizationService = authorizationService ?? throw new ArgumentNullException(nameof(authorizationService));
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest("Model has not been passed.");

            var result = await _authorizationService.LoginAsync(model);

            return Ok(result);
        }

        [Route("refresh")]
        [HttpPost]
        public async Task<IActionResult> RefreshTokens([FromBody]RefreshTokensModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest("Model has not been passed.");

            var result = await _authorizationService.RefreshTokensAsync(model);

            return Ok(result);
        }
    }
}
