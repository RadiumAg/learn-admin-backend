
using LearnAdmin.Model.Models;

namespace LearnAdmin.Repositories
{
    internal class UserRepository : BaseRepository<User>
    {
        public UserRepository(LearnAdminContext dbContext) : base(dbContext)
        {
        }
    }
}
