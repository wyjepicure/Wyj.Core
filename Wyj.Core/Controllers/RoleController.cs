using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wyj.Core.Dtos;
using Wyj.Core.IServices;
using Wyj.Core.Models;

namespace Wyj.Core.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _roelServices;
        private IMapper _mapper;
        private readonly IUserRoleServices _userRoleServices;

        public RoleController(IRoleServices roelServices, IMapper IMapper ,IUserRoleServices userRoleServices)
        {
            _roelServices = roelServices;
            _mapper = IMapper;
            _userRoleServices = userRoleServices;

        }
        [HttpPost("addRole")]
        public IActionResult AddRole(CreateOrUpdateRoleDto model)
        {
            var role = _mapper.Map<Role>(model);
            var result = _roelServices.AddRole(role);
            if (result!=null)
            {
                return Ok(new {message = "添加角色成功", result});
            }

            return new JsonResult(new { code="000005", message="添加失败"});
        }
        /// <summary>
        /// 新建用户角色关系
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        [HttpGet("AddUserRole")]
        public async Task<object> AddUserRole(int uid, int rid)
        {
            var model = await _userRoleServices.SaveUserRole(uid, rid);
            return Ok(new
            {
                success = true,
                data = model
            });
        }


    }
}
