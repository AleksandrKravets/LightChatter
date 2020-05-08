using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegistrationModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest("Model has not been passed.");

            var result = await _accountService.RegisterAsync(model);

            return Ok(result);
        }    

        [HttpGet]
        [Route("exists/{email}")]
        public async Task<IActionResult> CheckIfUserExists(string email)
        {
            var result = await _userService.CheckIfExistsAsync(email);
            return Ok(result);
        }
    }
}
