using AutoMapper;
using Business.Abstract;
using Business.Contants;
using Core.Results;
using DataAccess.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyManager
    {
        private ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }
        public IResult Add(Company company)
        {
            _companyDal.Create(company);
            return new Result(true, Messages.Added);
        }

        public IResult Delete(Company company)
        {
            _companyDal.Delete(company);
            return new Result(true, Messages.Added);
        }

        public IDataResult<List<Company>> GetAll()
        {
            return new DataResult<List<Company>>(_companyDal.GetList(), true);
        }

        public List<Company> GetAll2()
        {
            return _companyDal.GetList();
        }

        public IDataResult<Company> GetById(int id)
        {
            return new DataResult<Company>(_companyDal.Get(x => x.Id == id), true);
        }

        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new Result(true, Messages.Updated);
        }
    }
}
