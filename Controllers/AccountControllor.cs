using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeavrApi;
using YourNamespace.Models;
using YourNamespace.Services;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly Services.AccountService _accountService;

        public AccountController()
        {
        }

        public AccountController(IAccountService accountService)
        {
            _accountService = (Services.AccountService?)accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            IEnumerable<Account> accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        public interface IAccountService
        {
        }
    }
}
