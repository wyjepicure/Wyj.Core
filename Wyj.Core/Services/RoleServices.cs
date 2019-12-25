using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wyj.Core.IRepository;
using Wyj.Core.IRespository;
using Wyj.Core.IServices;
using Wyj.Core.Models;

namespace Wyj.Core.Services
{
    public class RoleServices :IRoleServices
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RoleServices(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }
        public Role AddRole(Role role)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                _roleRepository.Insert(role);

                _unitOfWork.CommitTransaction();

                return role;
            }
            catch (Exception e)
            {
                _unitOfWork.RollbackTransaction();
                throw e;
            }
        }

        public Role GetRoleById(int  id)
        {
            return   _roleRepository.GetByID(id);
        }

        public bool DeleteRole(Role role)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                _roleRepository.Delete(role);

                _unitOfWork.CommitTransaction();

                return true;
            }
            catch (Exception e)
            {
                _unitOfWork.RollbackTransaction();
                throw e;
            }
        }
    }
}
