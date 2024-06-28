using System.Linq.Expressions;
using LearnAdmin.Model.Models;

namespace LearnAdmin.IRepositories
{
	public interface IPdfRepository
	{
		void Add(Pdf pdf);
		void Delete(Pdf pdf);
		void Update(Pdf pdf);
		List<Pdf> Query(Expression<Func<Pdf, bool>> whereExpression);
	} 
}

