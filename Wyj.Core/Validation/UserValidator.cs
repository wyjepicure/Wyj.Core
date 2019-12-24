using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Wyj.Core.Dtos;
using Wyj.Core.Models;

namespace Wyj.Core.Validation
{
    public class UserValidator : AbstractValidator<CreateUpdateUserDto>
    {
        public UserValidator()
        {
            // 在这里添加规则
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("用户名为空");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("密码为空");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("邮箱为空");

        }

    }
    
}
