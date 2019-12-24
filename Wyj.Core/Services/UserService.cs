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

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public User AddUser(User user)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                _userRepository.Insert(user);
             
                _unitOfWork.CommitTransaction();

                return user;
            }
            catch (Exception e)
            {
                _unitOfWork.RollbackTransaction();
                throw e;
            }
        }

        public User GetUserByName(string name)
        {
            return _userRepository.Get(x => x.Name == name).FirstOrDefault();
        }
    }
}
