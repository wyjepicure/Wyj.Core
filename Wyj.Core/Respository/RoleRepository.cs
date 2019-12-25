using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wyj.Core.Data;
using Wyj.Core.IRepository;
using Wyj.Core.Models;
using Wyj.Core.Repository;

namespace Wyj.Core.Respository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(MyDbContext context) : base(context)
        {
        }
    }
}
