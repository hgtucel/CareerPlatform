using Core.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryManager
    {
        IDataResult<List<Category>> GetAll();
    }
}
