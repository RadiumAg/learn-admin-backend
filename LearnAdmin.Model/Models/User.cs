namespace LearnAdmin.Model.Models
{
    public class User : RootEntityTkey<int>
    {

        /// <summary>
        /// 账号
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>

        public string? Email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>

        public string? Password { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public Role? Role { get; set; }
    }
}
