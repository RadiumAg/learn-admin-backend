
using LearnAdmin.Model.Models;

namespace LearnAdmin.Repositories
{
    public class PdfRepository : BaseRepository<Pdf>
    {
        public PdfRepository(LearnAdminContext dbContext) : base(dbContext)
        {
        }
    }
}
