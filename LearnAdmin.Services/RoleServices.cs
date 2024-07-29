
using LearnAdmin.IServices;
using LearnAdmin.Model.Models;
using LearnAdmin.Repositories;

namespace LearnAdmin.Services
{
    public class RoleServices : BaseServices<Role>, IRoleServices
    {
        public RoleServices(IBaseRepository<Role> baseRepository) : base(baseRepository)
        {
        }
    }
}
