using Core.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAdvertManager
    {
        IDataResult<Advert> GetById(int id);
        IDataResult<List<Advert>> GetAll();
        IDataResult<List<Advert>> GetByCategory(int categoryId);
        IDataResult<List<Advert>> SearchByTitle(string title);

        IResult Add(Advert advert);
        IResult Delete(Advert advert);
        IResult Update(Advert advert);
    }
}
