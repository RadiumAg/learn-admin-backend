using AutoMapper;
using LearnAdmin.Dto.User;
using LearnAdmin.Model.Models;

namespace LearnAdmin.Extensions
{
    public class UserInfoProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public UserInfoProfile()
        {
            CreateMap<CreateUserInfoDto, User>();
        }
    }
}
