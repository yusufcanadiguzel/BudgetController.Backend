using Core.Utilities.Results.Abstract;
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
        IDataResult<IList<Company>> GetAll();
        IDataResult<IList<Company>> GetAllByName(string name);
        IDataResult<Company> GetById(int id);
        IResult Add(Company company);
        IResult Update(Company company);
        IResult Delete(Company company);
    }
}
