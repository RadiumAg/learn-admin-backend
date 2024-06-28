using System.Linq.Expressions;
using LearnAdmin.IRepositories;
using LearnAdmin.Model.Models;
using LearnAdmin.Repositories;

namespace LearnAdminBackend.Repositories
{
    public class PdfRepository : IPdfRepository
    {
        Task<Pdf> IBaseRepository<Pdf>.DeleteAsync(Pdf entity, bool autoSave, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Pdf> IBaseRepository<Pdf>.DeleteAsync(Expression<Func<Pdf, bool>> entity, bool autoSave, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Pdf> IBaseRepository<Pdf>.DeleteManyAsync(IEnumerable<Pdf> entities, bool autoSave, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Pdf> IBaseRepository<Pdf>.FindAsync(Expression<Func<Pdf, bool>> predicate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Pdf> IBaseRepository<Pdf>.GetAsync(Expression<Func<Pdf, bool>> predicate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<long> IBaseRepository<Pdf>.GetCountAsync(Expression<Func<Pdf, bool>> predicate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<List<Pdf>> IBaseRepository<Pdf>.GetListAsync(Expression<Func<Pdf, bool>> predicate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task IBaseRepository<Pdf>.GetPageListAsync(int skipCount, int maxResultCount, string sorting, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Pdf> IBaseRepository<Pdf>.InsertAsync(Pdf entity, bool autoSave, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        Task<Pdf> IBaseRepository<Pdf>.InsertManyAsync(Pdf entiry, bool autoSave, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Pdf> IBaseRepository<Pdf>.UpdateAsync(Pdf entity, bool autoSave, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<Pdf> IBaseRepository<Pdf>.UpdateManyAsync(IEnumerable<Pdf> entity, bool autoSave, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

