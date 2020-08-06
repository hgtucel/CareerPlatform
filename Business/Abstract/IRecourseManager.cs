using Core.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRecourseManager
    {
        IResult Add(Recourse recourse, int userId);
        IDataResult<List<Recourse>> GetByUserRecourse(int userId);
    }
}
