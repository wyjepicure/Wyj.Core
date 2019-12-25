using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wyj.Core.Dtos
{
    public class CreateOrUpdateRoleDto
    {
        public string RoleName { get; set; }

        public string Description { get; set; }
    }
}
