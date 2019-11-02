using Microsoft.AspNetCore.Mvc;
using PetShopApp.Core.ApplicationService;
using PetShopApp.UI.WebApp.Helper;
using PetShopApp.UI.WebApp.Models;

namespace PetShopApp.UI.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IAuthenticationHelper authenticationHelper;
        private readonly ILoginService _log;

        public TokenController(ILoginService log, IAuthenticationHelper authService)
        {
            _log = log;
            authenticationHelper = authService;
        }


        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var user = _log.Login(model.Username);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = authenticationHelper.GenerateToken(user)
            });
        }

    }
}

