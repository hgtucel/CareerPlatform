using Business.Abstract;
using Business.Contants;
using Core.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserManager
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Create(user);
        }

        public IDataResult<User> GetById(int id)
        {
            return new DataResult<User>(_userDal.Get(x => x.Id == id), true);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(x => x.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}
