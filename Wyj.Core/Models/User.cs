using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wyj.Core.Models
{
    public class User
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime CreateTime { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
