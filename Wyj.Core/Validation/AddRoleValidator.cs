using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Wyj.Core.Dtos;

namespace Wyj.Core.Validation
{
    public class AddRoleValidator : AbstractValidator<CreateOrUpdateRoleDto>
    {
        public AddRoleValidator()
        {
            // 在这里添加规则
            RuleFor(x => x.RoleName)
                .NotEmpty()
                .WithMessage("角色名为空");


        }
    }
}
