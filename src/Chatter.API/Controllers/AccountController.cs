using Chatter.Application.Contracts.Services;
using Chatter.Application.DataTransferObjects.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Chatter.WebUI.Controllers
{
    // POST http://localhost:59864/api/account { Email:string, Password:string, Nickname:string }
    // POST http://localhost:59864/api/account/exists/email:string

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
            await _accountService.RegisterAsync(model);
            return Ok();
        }    

        [HttpGet]
        [Route("exists/{email:string}")]
        public async Task<IActionResult> CheckIfUserExists(string email)
        {
            var result = await _userService.CheckIfUserExistsAsync(email);
            return Ok(result);
        }
    }
}
