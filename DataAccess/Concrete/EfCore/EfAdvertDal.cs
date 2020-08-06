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
    public class EfAdvertDal: EfGenericRepository<Advert,CareerContext>, IAdvertDal
    {
        public override Advert Get(Expression<Func<Advert, bool>> filter = null)
        {
            using(var context = new CareerContext())
            {
                return context.Adverts.Include(x => x.Category).Include(x=>x.User).SingleOrDefault(filter);
            }
        }

        public override List<Advert> GetList(Expression<Func<Advert, bool>> filter = null)
        {
            using (var context = new CareerContext())
            {
                return filter == null ? context.Adverts.Include(x => x.Category).Include(x => x.User).ThenInclude(x => x.Company).ToList() : context.Adverts.Where(filter).ToList();
            }
        }
    }
}
