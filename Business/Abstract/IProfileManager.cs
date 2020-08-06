using Core.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProfileManager
    {
        IDataResult<Profile> GetById(int id);
        IResult Add(Profile profile);
        IResult Update(Profile profile,int reqUserId);

    }
}
