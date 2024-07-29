using AutoMapper;
using LearnAdmin.Model.Models;
using LearnAdmin.Model.Models.ViewModels.User;

namespace LearnAdmin.Extensions
{
    public class UserInfoProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public UserInfoProfile()
        {
            CreateMap<CreateUserInfoDto, User>()
                .ForMember(dest => dest.Role, opt => opt.Ignore());
        }
    }
}
