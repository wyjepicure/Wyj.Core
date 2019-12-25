using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wyj.Core.Models
{
    public class UserRole
    {
        public UserRole()
        {
                
        }
        public UserRole(int uid, int rid)
        {
            UserId = uid;
            RoleId = rid;
           
         
            CreateId = uid;
            CreateTime = DateTime.Now;
        }
        public DateTime? CreateTime { get; set; }
        public int? CreateId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
