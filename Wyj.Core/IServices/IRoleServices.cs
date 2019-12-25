using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wyj.Core.Models;

namespace Wyj.Core.IServices
{
    public interface IRoleServices
    {
        Role AddRole(Role role);
        Role GetRoleById(int id);

        bool DeleteRole(Role role);
    }
}
