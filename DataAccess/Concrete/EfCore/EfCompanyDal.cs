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
    public class EfCompanyDal: EfGenericRepository<Company, CareerContext>, ICompanyDal
    {
        public override List<Company> GetList(Expression<Func<Company, bool>> filter = null)
        {
            using(var context = new CareerContext())
            {
                return filter == null ? context.Companies.Include(x=>x.User).ToList() : context.Companies.Where(filter).ToList();
            }
        }
    }
}
