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
    public class EfRecourseDal : EfGenericRepository<Recourse, CareerContext>, IRecourseDal
    {
        public override List<Recourse> GetList(Expression<Func<Recourse, bool>> filter = null)
        {
            using(var context = new CareerContext())
            {
                return filter == null ? context.Recourses.ToList() : context.Recourses.Include(x => x.Advert).Where(filter).ToList();
            }
        }
    }
}
