﻿using learn_admin_backend.Database;
using learn_admin_backend.Dto.User;
using learn_admin_backend.Share;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace learn_admin_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        public readonly LearnAdminContext learnAdminContex;

        public UserController(LearnAdminContext learnAdminContex)
        {
            this.learnAdminContex = learnAdminContex;
        }

        [Authorize]
        [HttpPost]
        [Route("CreateUserInfo")]
        public MessageModel<string> CreateUser([FromBody] CreateUserInfoDto userData)
        {
            var user = new User
            {
                Account = userData.Account,
                Email = userData.Email,
                Name = userData.Name,
                Password = userData.Password,
            };

            this.learnAdminContex.Users.Add(user);
            this.learnAdminContex.SaveChanges();

            return Success("");
        }

        [Authorize]
        [HttpPost]
        [Route("GetUserInfo")]
        public MessageModel<string> GetUserInfo([FromBody] GetUserInfoDto data)
        {
            var result = this.learnAdminContex.Users.Where((user) => user.Account == data.Account && user.Password == data.Password).ToList();
            return Success("");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<MessageModel<string>> Login([FromQuery] string account, [FromQuery] string password)
        {
            var user = await this.learnAdminContex.Users
                .Where(user => user.Account == account && user.Password == password)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, nameof(Role.Administorator))
                };
                var claimsIdentity = new ClaimsIdentity(claims);
                await HttpContext.SignInAsync(
                           CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity));
                return Success("");
            }
            else
            {
                return Failed("");
            }
        }

    }
}
