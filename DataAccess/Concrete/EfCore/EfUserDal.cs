using Core.DataAccess.Concrete.EfCore;
using DataAccess.Abstract;
using DataAccess.Concrete.EfCore.Contexts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EfCore
{
    public class EfUserDal : EfGenericRepository<User, CareerContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CareerContext())
            {
                //Birbirine tam bağlı olmayan tabloları join etme
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId //on->hangi koşula göre operationClaim'in ıdsinin değeri userOperationclaimdeki ıd olmalı.
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }

        public override User Get(Expression<Func<User, bool>> filter)
        {
            using (var context = new CareerContext())
            {
                return context.Users.Include(x => x.Profile).SingleOrDefault(filter);
            }
        }

    }
}
