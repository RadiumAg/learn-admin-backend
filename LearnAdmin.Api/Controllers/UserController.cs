using AutoMapper;
using LearnAdmin.Dto.User;
using LearnAdmin.IServices;
using LearnAdmin.Model.Models;
using LearnAdmin.Model.Models.ViewModels.User;
using LearnAdmin.Repositories;
using LearnAdmin.Share;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace LearnAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;
        private readonly IUserServices _userServices;
        private readonly IRoleServices _roleServices;


        public UserController(
            IUserServices userServices, 
            IRoleServices roleServices,
            LearnAdminContext dbContext,
            IMapper mapper)
        {
            this._mapper = mapper;
            this._dbContext = dbContext;
            this._userServices = userServices;
            this._roleServices = roleServices;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<MessageModel> Login([FromBody] GetUserInfoDto user)
        {
            var userInfo = await this._userServices.FindAsync(userInfo => userInfo.Name == user.Account
            && userInfo.Password == user.Password);

            if (userInfo == null || userInfo.Name == null)
            {
                return Fail("不存在的用户");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userInfo.Name),
                new Claim("Id" , userInfo.Id.ToString()),
                new Claim(ClaimTypes.Role, nameof(EUserRole.User))
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return Success();
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("CreateUserInfo")]
        public async Task<MessageModel<User>> CreateUserInfo([FromBody] CreateUserInfoDto user)
        {
            var userInfo = _mapper.Map<User>(user);
            var RoleArray = await this._roleServices.GetListAsync(role => user.RoleId.Contains(role.Id));
            userInfo.Role = RoleArray;

            using (var tranisition = _dbContext.Database.BeginTransaction())
            {
                await this._userServices.InsertAsync(userInfo, true);
                tranisition.Commit();
            }

            return Success<User>(userInfo);
        }

        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("GetUserInfo")]
        public async Task<MessageModel<User>> GetUserInfo([FromQuery] long? userId)
        {
            string? userIdFromCookie;
            HttpContext.Request.Cookies.TryGetValue("Id", out userIdFromCookie);
            userId = userId ?? Convert.ToInt64(userIdFromCookie);
            var userInfo = await _userServices.GetAsync(user => user.Id == userId);

            if (userInfo is null)
                return Fail<User>(null, "获得信息失败");


            return Success(userInfo);
        }

    }
}
