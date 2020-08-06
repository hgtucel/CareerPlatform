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
    public class EfProfileDal: EfGenericRepository<Profile,CareerContext>, IProfileDal
    {
        /*public override void Update(Profile entity)
        {
            using(var context = new CareerContext())
            {
                var dbProfile = context.Profiles.Include(x=>x.User).FirstOrDefault(x => x.Id == entity.Id);

                if(dbProfile != null)
                {
                    dbProfile.Email = entity.Email;
                    dbProfile.Name = entity.Name;
                    dbProfile.BirthDay = entity.BirthDay;
                    dbProfile.UserId = entity.UserId;
                    dbProfile.User = entity.User;

                    context.SaveChanges();
                }
            }
        }*/
    }
}
