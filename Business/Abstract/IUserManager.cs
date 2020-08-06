using Core.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserManager
    {
        void Add(User user);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);

        IDataResult<User> GetById(int id);
    }
}
