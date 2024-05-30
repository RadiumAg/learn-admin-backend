namespace learn_admin_backend.Database
{
    public class User
    {

        /// <summary>
        ///  Id
        /// </summary>
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
