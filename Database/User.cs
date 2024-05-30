namespace learn_admin_backend.Database
{
    public class User
    {

        /// <summary>
        ///  Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>

        public string Email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>

        public string Password { get; set; }
    }
}
