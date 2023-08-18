using AutoMapper;
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
        private readonly IMapper _mapper;

        public UsersController(UserManager<Users> userManager, IMapper mapper)
        {
            this._userManager = userManager;
            this._mapper = mapper;
        }

        //[HttpPost("RegisterUser")]
        //public IActionResult RegisterUser()
        //{

        //}
    }
}
