using LearnAdmin.IServices;
using LearnAdmin.Model.Models;
using LearnAdmin.Repositories;

namespace LearnAdmin.Services
{
    public class PdfServices : BaseServices<Pdf>, IPdfServices
    {
        public PdfServices(IBaseRepository<Pdf> baseRepository) : base(baseRepository)
        {
        }
    }

}