using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YourNamespace.Models;
using YourNamespace.Services;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            IEnumerable<Account> accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }

        // Implement other CRUD actions
    }
}
