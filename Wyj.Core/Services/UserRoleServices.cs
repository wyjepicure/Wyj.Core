using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wyj.Core.IRepository;
using Wyj.Core.IRespository;
using Wyj.Core.IServices;
using Wyj.Core.Models;

namespace Wyj.Core.Services
{
    public class UserRoleServices : IUserRoleServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleServices(IUserRepository userRepository, IUnitOfWork unitOfWork,IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _unitOfWork = unitOfWork;
        }
        [HttpPost("SaveUserRole")]
        public async Task<UserRole> SaveUserRole(int uid, int rid)
        {
            UserRole userRole = new UserRole(uid, rid);

            UserRole model = new UserRole();
            var userList = _userRoleRepository.Get(a => a.UserId == userRole.UserId && a.RoleId == userRole.RoleId).ToList();
            if (userList.Count > 0)
            {
                model = userList.FirstOrDefault();
            }
            else
            {
                _unitOfWork.BeginTransaction();
              _userRoleRepository.Insert(userRole);
              _unitOfWork.CommitTransaction();
              model = userRole;
            }

            return model;
        }

        public async Task<int> GetRoleIdByUid(int uid)
        {
         var role =   _userRoleRepository.Get(d => d.UserId == uid).FirstOrDefault();
         return role.RoleId;
        }
    }
}
