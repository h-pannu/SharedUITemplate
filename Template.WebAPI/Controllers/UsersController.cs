using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Template.WebAPI.Data;

namespace Template.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;

        public UsersController(UserManager<Users> userManager)
        {
            this._userManager = userManager;
        }

        //[HttpPost("RegisterUser")]
        //public IActionResult RegisterUser()
        //{

        //}
    }
}
