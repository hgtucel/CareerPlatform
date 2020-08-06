using Business.Abstract;
using Business.Contants;
using Core.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RecourseManager : IRecourseManager
    {

        private IRecourseDal _recourseDal;

        public RecourseManager(IRecourseDal recourseDal)
        {
            _recourseDal = recourseDal;
        }

        public IResult Add(Recourse recourse, int userId)
        {
            if(recourse.UserId != userId)
            {
                _recourseDal.Create(recourse);
                return new Result(true, Messages.Added);
            }
            return new Result(false, Messages.BeforeRecourse);
        }

        public IDataResult<List<Recourse>> GetByUserRecourse(int userId)
        {
            return new DataResult<List<Recourse>>(_recourseDal.GetList(x => x.UserId == userId), true);
        }
    }
}
