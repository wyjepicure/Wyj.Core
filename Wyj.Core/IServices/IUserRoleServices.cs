using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wyj.Core.Models;

namespace Wyj.Core.IServices
{
 public   interface IUserRoleServices
    {
        Task<UserRole> SaveUserRole(int uid, int rid);
        Task<int> GetRoleIdByUid(int uid);
    }
}
