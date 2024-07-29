using LearnAdmin.Share;
using System.ComponentModel.DataAnnotations;

namespace LearnAdmin.Model.Models.ViewModels.User
{
    public class CreateUserInfoDto
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required(ErrorMessage = "Account is required.")]
        public string Account { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        [Required(ErrorMessage = "Role is required.")]
        public EUserRole RoleId { get; set; }

    }
}

