using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SchoolWith.Core.Dtos.Users;
using SchoolWith.Core.Interfaces;
using SchoolWith.Core.Models;
using SchoolWith.EF.Services;

namespace School_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController(IAuthServices authService, UserManager<User> userManager, IStringLocalizer<string> localizer, IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager) : ControllerBase
    {
        private readonly IAuthServices _authService = authService;
        private readonly UserManager<User> _userManager = userManager;
        private readonly IStringLocalizer<string> _localizer = localizer;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly SignInManager<User> _SignInManager;
        [HttpPost("AddUser")]
        //[Authorize(Permissions.Users.Create)]
        public async Task<IActionResult> AddUser(AddUserDto userRegister)
        {
            var user = await _authService.AddUser(userRegister);
            if (!user.IsAuth)
                return BadRequest(user.Massage);
            return Ok(user);
        }
    }
}
