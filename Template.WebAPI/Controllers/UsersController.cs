using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Template.WebAPI.Data;
using Template.WebAPI.DTO;

namespace Template.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        private readonly IMapper _mapper;

        public UsersController(UserManager<Users> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        //Post Method to create new user
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            Users users = _mapper.Map<Users>(registerUserDTO);
            var response = await _userManager.CreateAsync(users,registerUserDTO.Password);

            if(response.Succeeded)
            {
                return Ok("User Created");
            }
            else
            {
                return BadRequest(response.Errors);
            }
        }

        //Delete method to delete existing user by email.
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(DeleteUserDTO deleteUserDTO)
        {
            //Users users = _mapper.Map<Users>(deleteUserDTO);
            var existingUser = await _userManager.FindByEmailAsync(deleteUserDTO.Email);
            if(existingUser != null)
            {
                var response = await _userManager.DeleteAsync(existingUser);
                if (response.Succeeded)
                {
                    return Ok("User Deleted");
                }
                else
                {
                    return BadRequest(response.Errors);
                }
            }
            else
            {
                return BadRequest("No user found with this email");
            }

        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleDTO createRoleDTO)
        {
            IdentityRole role = _mapper.Map<IdentityRole>(createRoleDTO);
            var response = await _roleManager.CreateAsync(role);

            if (response.Succeeded)
            {
                return Ok("New Role Created");
            }
            else
            {
                return BadRequest(response.Errors);
            }
        }

        [HttpPost("AssignRoleToUser")]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserDTO assignRoleToUserDTO)
        {
            var UserDetails = await _userManager.FindByEmailAsync(assignRoleToUserDTO.Email);
            if (UserDetails != null)
            {
                var userRoleAssignResponse = await _userManager.AddToRoleAsync(UserDetails, assignRoleToUserDTO.RoleName);

                if(userRoleAssignResponse.Succeeded)
                {
                    return Ok("Role Assigned to user: " + assignRoleToUserDTO.RoleName);
                }
                else
                {
                    return BadRequest(userRoleAssignResponse.Errors);
                }
            }
            else
            {
                return BadRequest("No User exist with this email.");
            }
        }

        [AllowAnonymous]
        [HttpPost("AuthenticateUser")]
        public async Task<IActionResult> AuthenticateUser(AuthenticateUser authenticateUser)
        {
            var user = await _userManager.FindByNameAsync(authenticateUser.UserName);
            if (user == null) return Unauthorized();

            bool isValidUser = await _userManager.CheckPasswordAsync(user, authenticateUser.Password);

            if (isValidUser)
            {
                string accessToken = GenerateAccessToken(user);
                
                return Ok(accessToken);
            }
            else
            {
                return Unauthorized();
            }
        }

        private string GenerateAccessToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var keyDetail = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, $"{user.FirstName} { user.LastName}"),
                    new Claim(ClaimTypes.Email, user.Email),

            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _configuration["JWT:Audience"],
                Issuer = _configuration["JWT:Issuer"],
                Expires = DateTime.UtcNow.AddMinutes(30),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyDetail), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        
    }
}
