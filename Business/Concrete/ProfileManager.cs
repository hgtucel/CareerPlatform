using Business.Abstract;
using Business.Contants;
using Core.Helpers;
using Core.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProfileManager : IProfileManager
    {
        private IProfileDal _profileDal;
        public ProfileManager(IProfileDal profileDal)
        {
            _profileDal = profileDal;
        }
        public IResult Add(Profile profile)
        {
            _profileDal.Create(profile);
            return new Result(true, Messages.Added);
        }

        public IDataResult<Profile> GetById(int id)
        {
           return new DataResult<Profile>(_profileDal.Get(x => x.Id == id),true);
        }

        public IResult Update(Profile profile, int reqUserId)
        {
            if (!AuthorHelper.OwnerAccess(profile.UserId,reqUserId))
            {
                return new Result(false, Messages.OwnerAccess);
            }
            _profileDal.Update(profile);
            return new Result(true, Messages.Updated);
        }
    }
}
