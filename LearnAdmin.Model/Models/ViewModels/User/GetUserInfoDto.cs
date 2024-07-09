namespace LearnAdmin.Dto.User
{
    public class GetUserInfoDto
    {
        public string Account { get; set; }

        public string Password { get; set; }
    }


    public class CreateUserInfoDto
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

    }
}
