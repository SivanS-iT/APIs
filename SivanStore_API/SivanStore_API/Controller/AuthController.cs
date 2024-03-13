using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RedMango_API.Services;
using SivanStore_API.Data;
using SivanStore_API.Models;
using SivanStore_API.Models.Dto;
using SivanStore_API.Utility;
using System.Net;

namespace SivanStore_API.Controller
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ApiResponse _response;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string secretKey;

        public AuthController(ApplicationDbContext db, IConfiguration configuration,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _response = new ApiResponse();
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto model)
        {
            ApplicationUser userFromDb = _db.ApplicationUsers
                .FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());

            if (userFromDb != null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
            }

            ApplicationUser newUser = new()
            {
                UserName = model.UserName,
                Email = model.UserName,
                NormalizedEmail = model.UserName.ToUpper(),
                Name = model.Name,
            };


            try
            {
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync(Helper.Role_Admin).GetAwaiter().GetResult())
                    {
                        //create roles in database
                        await _roleManager.CreateAsync(new IdentityRole(Helper.Role_Admin));
                        await _roleManager.CreateAsync(new IdentityRole(Helper.Role_Customer));
                    }
                    if (model.Role.ToLower() == Helper.Role_Admin)
                    {
                        await _userManager.AddToRoleAsync(newUser, Helper.Role_Admin);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(newUser, Helper.Role_Customer);
                    }

                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    return Ok(_response);
                }
            }
            catch (Exception)
            {

            }
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Error while registering");
            return BadRequest(_response);

        }




    }
}
