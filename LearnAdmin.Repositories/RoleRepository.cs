
using LearnAdmin.Model.Models;

namespace LearnAdmin.Repositories
{
    internal class RoleRepository : BaseRepository<Role>
    {
        public RoleRepository(LearnAdminContext dbContext) : base(dbContext)
        {
        }
    }
}
