using Business.Abstract;
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

        public void Add(Company company)
        {
            _companyDao.Add(company);
        }

        public void Delete(Company company)
        {
            _companyDao.Delete(company);
        }

        public IList<Company> GetAll()
        {
            var result = _companyDao.GetAll();

            return result;
        }

        public IList<Company> GetAllByName(string name)
        {
            var result = _companyDao.GetAll(c => c.Name.ToLower().Contains(name.ToLower()));

            return result;
        }

        public Company GetById(int id)
        {
            var result = _companyDao.Get(c => c.Id == id);

            return result;
        }

        public void Update(Company company)
        {
            _companyDao.Update(company);
        }
    }
}
