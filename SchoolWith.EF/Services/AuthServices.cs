using Jose;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using SchoolWith.Core.Dtos.Users;
using SchoolWith.Core.Interfaces;
using SchoolWith.Core.Models;
using SchoolWith.Core.Helpers;

using SchoolWith.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWT = SchoolWith.Core.Helpers.JWT;
using Microsoft.EntityFrameworkCore;
using Mapster;
using SchoolWith.Core.Enums.Roles;
using System.IdentityModel.Tokens.Jwt;

namespace SchoolWith.EF.Services
{
    public class AuthServices(UserManager<User> userManager, IOptions<JWT> jwt, SignInManager<User> signInManager, SchoolDbContext context, IStringLocalizer<string> localizer, RoleManager<IdentityRole> roleManager) : IAuthServices
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly SignInManager<User> _signInManager = signInManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly JWT _jwt = jwt.Value;
        private readonly SchoolDbContext _context = context;
        private readonly IStringLocalizer<string> _localizer = localizer;
        public async Task<ReturnAuth> AddUser(AddUserDto userRegister)
        {
            var authReturn = new ReturnAuth();
            var exitUser = await _userManager.FindByNameAsync(userRegister.UserName);
            if (exitUser != null)
            {
                authReturn.Massage = string.Format(_localizer["This user name already exists!"]);
            }
            else if (await _userManager.FindByEmailAsync(userRegister.Email) != null)
            {
                authReturn.Massage = string.Format(_localizer["This email already exists"]);
            }
            else if (userRegister.PhoneNumber != null && userRegister.PhoneNumber != string.Empty && await _context.Users.Where(U => U.PhoneNumber == userRegister.PhoneNumber).AnyAsync())
            {
                authReturn.Massage = string.Format(_localizer["This Phone Number already exits!"]);
            }
            else
            {
                var user = userRegister.Adapt<User>();
                user.CreatedAt = DateTime.Now;
                user.EmailConfirmed = true;
                var result = await _userManager.CreateAsync(user, userRegister.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Enum.GetName(typeof(Roles), userRegister.Role));
                    authReturn.IsAuth = true;
                    //var token = await CreateJwtToken(user);
                    authReturn = new ReturnAuth
                    {
                        Id = user.Id,
                        Email = user.Email,
                        IsAuth = true,
                        Name = user.UserName,
                        Massage =
                        string.Format(_localizer["User in Role {0} Created successfully"], userRegister.Role.ToString()),
                        //Token = new JwtSecurityTokenHandler().WriteToken(token),
                        //ExpiresOn = token.ValidTo
                    };
                }
                if (result != null && result.Errors.Any())
{
    authReturn.Massage = result.Errors.First().Description;
}
else
{
    authReturn.Massage = "Unknown error occurred";
}
                //authReturn.Massage = result.Errors.FirstOrDefault().Description;
            }
            return authReturn;
        }

        public Task<ReturnAuth> EditUser(EditUserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
