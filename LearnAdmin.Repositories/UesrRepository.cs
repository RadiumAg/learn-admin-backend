
using LearnAdmin.Model.Models;

namespace LearnAdmin.Repositories
{
    internal class UesrRepository : BaseRepository<User>
    {
        public UesrRepository(LearnAdminContext dbContext) : base(dbContext)
        {
        }
    }
}
