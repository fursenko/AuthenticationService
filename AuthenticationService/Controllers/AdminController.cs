using AuthenticationService.DataAccess;
using AuthenticationService.IdentityProvider;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AdminController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var context = new AuthContext();
            var data = context.Users.Include(_ => _.Roles).ToList();
            return Ok(data);
        }
    }
}
