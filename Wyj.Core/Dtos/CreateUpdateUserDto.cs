using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wyj.Core.Dtos
{
    public class CreateUpdateUserDto
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
