using Core.Results;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyManager
    {
        IDataResult<Company> GetById(int id);
        IDataResult<List<Company>> GetAll();
        List<Company> GetAll2();

        IResult Add(Company company);
        IResult Delete(Company company);
        IResult Update(Company company);
    }
}
