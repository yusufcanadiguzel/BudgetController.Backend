using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        IList<Company> GetAll();
        IList<Company> GetAllByName(string name);
        Company GetById(int id);
        void Add(Company company);
        void Update(Company company);
        void Delete(Company company);
    }
}
