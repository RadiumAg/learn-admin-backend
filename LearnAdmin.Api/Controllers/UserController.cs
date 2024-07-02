using LearnAdmin.Dto.User;
using LearnAdmin.Share;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using LearnAdmin.Repositories;
using LearnAdmin.Model.Models;

namespace LearnAdmin.Controllers
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
        public MessageModel CreateUser([FromBody] CreateUserInfoDto userData)
        {
            var user = new User
            {
                Account = userData.Account,
                Email = userData.Email,
                Name = userData.Name,
                Password = userData.Password,
            };

            this.learnAdminContex.SaveChanges();

            return Success();
        }

        [Authorize]
        [HttpPost]
        [Route("GetUserInfo")]
        public MessageModel GetUserInfo([FromBody] GetUserInfoDto data)
        {
            var result = this.learnAdminContex.Users.Where((user) => user.Account == data.Account && user.Password == data.Password).ToList();
            return Success();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<MessageModel> Login([FromQuery] string account, [FromQuery] string password)
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
                return Success();
            }
            else
            {
                return Fail();
            }
        }

    }
}
