using Business.Abstract;
using Business.Contants;
using Core.Helpers;
using Core.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Business.Concrete
{
    public class AdvertManager : IAdvertManager
    {
        private IAdvertDal _advertDal;

        public AdvertManager(IAdvertDal advertDal)
        {
            _advertDal = advertDal;
        }

        public IResult Add(Advert advert)
        {
            try
            {
                _advertDal.Create(advert);
                return new Result(true, Messages.Added);
            }
            catch (Exception error)
            {
                return new Result(false, error.Message);
            }
        }

        public IResult Delete(Advert advert)
        {
            try
            {
                _advertDal.Delete(advert);
                return new Result(true, Messages.Deleted);
            }
            catch (Exception error)
            {
                return new Result(false, error.Message);
            }
        }

        public IDataResult<List<Advert>> GetAll()
        {
            try
            {
                return new DataResult<List<Advert>>(_advertDal.GetList(), true);
            }
            catch (Exception error)
            {
                return new DataResult<List<Advert>>(error.Message);
            }
        }

        public IDataResult<List<Advert>> GetByCategory(int categoryId)
        {
            try
            {
                return new DataResult<List<Advert>>(_advertDal.GetList(x=>x.Category.Id == categoryId), true);
            }
            catch (Exception error)
            {
                return new DataResult<List<Advert>>(error.Message);
            }
        }

        public IDataResult<Advert> GetById(int id)
        {
            try
            {
                return new DataResult<Advert>(_advertDal.Get(x => x.Id == id), true);
            }
            catch (Exception error)
            {
                return new DataResult<Advert>(error.Message);
            }
        }

        public IDataResult<List<Advert>> SearchByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return new DataResult<List<Advert>>(Messages.SearchNull);
            }

            return new DataResult<List<Advert>>(_advertDal.GetList(x => x.Title.ToLower().Contains(title.Trim().ToLower())), true);
        }

        public IResult Update(Advert advert)
        {
            try
            {
                if (!AuthorHelper.OwnerAccess(advert.UserId,advert.User.Id))
                {
                    return new Result(false, Messages.OwnerAccess);
                }
                
                _advertDal.Update(advert);
                return new Result(true, Messages.Updated);
            }
            catch (Exception error)
            {
                return new Result(false, error.Message);
            }
        }
    }
}
