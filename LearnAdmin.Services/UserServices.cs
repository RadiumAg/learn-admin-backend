
using LearnAdmin.IServices;
using LearnAdmin.Model.Models;
using LearnAdmin.Repositories;

namespace LearnAdmin.Services
{
    public class UserServices : BaseServices<User>, IUserServices
    {
        public UserServices(IBaseRepository<User> baseRepository) : base(baseRepository)
        {
        }
    }
}
