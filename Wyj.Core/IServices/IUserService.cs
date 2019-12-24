using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wyj.Core.Models;

namespace Wyj.Core.IServices
{
    public interface IUserService

    {
    User AddUser(User user);
    User GetUserByName(string name);
    }
}
