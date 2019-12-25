using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.Unicode;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Wyj.Core.Dtos;
using Wyj.Core.Filter;
using Wyj.Core.Helper;
using Wyj.Core.Helper.AuthHelper;
using Wyj.Core.IServices;
using Wyj.Core.Models;

namespace Wyj.Core.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    [AddHeader("myName", "wyj")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private IMapper _mapper;
        public AccountController(IUserService userService, IMapper IMapper)
        {
            _userService = userService;
            _mapper = IMapper;

        }
        [HttpPost("Register")]
        public IActionResult Register(CreateUpdateUserDto model)
        {

            model.Password = model.Password.GetMd5String();

            model.CreateTime = DateTime.Now;
            var user = _mapper.Map<User>(model);
            _userService.AddUser(user);
            return Ok("success");

        }
        
        [HttpGet("login")]
        public IActionResult Login(string userName, string password)
        {
            var user = _userService.GetUserByName(userName);
            if ((user.Password).Equals(password.GetMd5String()))
            {
                return Ok(new { message="登录成功",user });
            }

            return NotFound();

        }
      
        [HttpGet("login")]
        public async Task<object> GetJwtStr(string userName, string password)
        {
            string jwtStr = string.Empty;
            bool suc = false;
            var user = _userService.GetUserByName(userName);
            if ((user.Password).Equals(password.GetMd5String()))
            {
                return Ok(new { message = "登录成功", user });
            }
            // 获取用户的角色名，请暂时忽略其内部是如何获取的，可以直接用 var userRole="Admin"; 来代替更好理解。
            //var userRole = await _sysUserInfoServices.GetUserRoleNameStr(name, pass);
            //if (userRole != null)
            //{
            //    // 将用户id和角色名，作为单独的自定义变量封装进 token 字符串中。
            //    JwtHelper.TokenModelJwt tokenModel = new JwtHelper.TokenModelJwt { Uid = 1, Role = userRole };
            //    jwtStr = JwtHelper.IssueJwt(tokenModel);//登录，获取到一定规则的 Token 令牌
            //    suc = true;
            //}
            //else
            //{
            //    jwtStr = "login fail!!!";
            //}

            return Ok(new
            {
                success = suc,
                token = jwtStr
            });
        }
    }
}
