using Business.Abstract;
using Business.BusinessAspects.Authorization.Autofac.Concrete;
using Business.Constants.Concrete;
using Business.Validation.FluentValidation;
using Core.Aspects.Validation.Autofac;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDao _companyDao;

        public CompanyManager(ICompanyDao companyDao)
        {
            _companyDao = companyDao;
        }

        [AfAuthorizationAspect(roles: "Companies.Add", Priority = 1)]
        [AfValidationAspect(typeof(FvCompanyValidator), Priority = 2)]
        public IResult Add(Company company)
        {
            _companyDao.Add(company);

            return new SuccessResult(message: Messages.CompanyAdded);
        }

        [AfAuthorizationAspect(roles: "Companies.Delete")]
        public IResult Delete(Company company)
        {
            _companyDao.Delete(company);

            return new SuccessResult(message: Messages.CompanyDeleted);
        }

        [AfAuthorizationAspect(roles: "Companies.GetAll")]
        public IDataResult<IList<Company>> GetAll()
        {
            var result = _companyDao.GetAll();

            return new SuccessDataResult<IList<Company>>(data: result);
        }

        [AfAuthorizationAspect(roles: "Companies.GetAllByName")]
        public IDataResult<IList<Company>> GetAllByName(string name)
        {
            var result = _companyDao.GetAll(c => c.Name.ToLower().Contains(name.ToLower()));

            return new SuccessDataResult<IList<Company>>(data: result);
        }

        [AfAuthorizationAspect(roles: "Companies.GetById")]
        public IDataResult<Company> GetById(int id)
        {
            var result = _companyDao.Get(c => c.Id == id);

            return new SuccessDataResult<Company>(data: result);
        }

        [AfAuthorizationAspect(roles: "Companies.Update", Priority = 1)]
        [AfValidationAspect(typeof(FvCompanyValidator), Priority = 2)]
        public IResult Update(Company company)
        {
            _companyDao.Update(company);

            return new SuccessResult(message: Messages.CompanyUpdated);
        }
    }
}
