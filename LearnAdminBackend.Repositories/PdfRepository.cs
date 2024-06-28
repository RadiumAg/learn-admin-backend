using System.Linq.Expressions;
using LearnAdmin.IRepositories;
using LearnAdmin.Model.Models;

namespace LearnAdminBackend.Repositories
{
	public class PdfRepository: IPdfRepository
    {
		public PdfRepository()
		{
		}

        public void Add(Pdf pdf)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pdf pdf)
        {
            throw new NotImplementedException();
        }

        public List<Pdf> Query(Expression<Func<Pdf, bool>> whereExpression)
        {
            throw new NotImplementedException();
        }

        public void Update(Pdf pdf)
        {
            throw new NotImplementedException();
        }
    }
}

