﻿using learn_admin_backend.Database;
using learn_admin_backend.Dto.User;
using learn_admin_backend.Share;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

        [HttpPost]
        [Route("CreateUserInfo")] CreateUserInfo([FromBody] CreateUserInfoDto  userData)
        public MessageModel<string> 


        [HttpPost]
        [Route("GetUserInfo")]
        public MessageModel<List<User>> GetUserInfo([FromBody] GetUserInfoDto data)
        {
            var result = this.learnAdminContex.Users.Where((user) => user.Account == data.Account && user.Password == data.Password).ToList();
            return Success(result);
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
                new Claim(ClaimTypes.Role, "Administorator")
                };

                var authProperties = new AuthenticationProperties { };
                var claimsIdentity = new ClaimsIdentity(claims);

                await HttpContext.SignInAsync(
                           CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);
                return Success("");

            }
            else
            {
                return Failed("");
            }
        }

    }
}
