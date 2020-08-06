using Core.DataAccess.Concrete.EfCore;
using DataAccess.Abstract;
using DataAccess.Concrete.EfCore.Contexts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EfCore
{
    public class EfCategoryDal: EfGenericRepository<Category, CareerContext>, ICategoryDal
    {
    }
}
