
using LearnAdmin.Share;

namespace LearnAdmin.Model.Models
{
    public class Role : RootEntityTkey<int>
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string? RoleName { get; set; }

        /// <summary>
        /// 角色对应的枚举类型
        /// </summary>
        public EUserRole RoleNumber { get; set; }

        /// <summary>
        /// 角色拥有的用户
        /// </summary>
        public List<User> User { get; set; }
    }
}
