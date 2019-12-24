using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Wyj.Core.Dtos;
using Wyj.Core.Models;

namespace Wyj.Core.AutoMapper
{
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            CreateMap<User, CreateUpdateUserDto>();
            CreateMap<CreateUpdateUserDto, User>();
        }
    }
}
