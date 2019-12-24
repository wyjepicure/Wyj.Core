using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.Unicode;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Wyj.Core.Dtos;
using Wyj.Core.Filter;
using Wyj.Core.Helper;
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

    }
}
