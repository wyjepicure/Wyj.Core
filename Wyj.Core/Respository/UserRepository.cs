using Wyj.Core.Data;
using Wyj.Core.IRepository;
using Wyj.Core.Models;
using Wyj.Core.Repository;

namespace Wyj.Core.Respository
{
    public class UserRepository :BaseRepository<User> ,IUserRepository
    {
        public UserRepository(MyDbContext context) : base(context)
        {
        }
    }
}
