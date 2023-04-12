using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReceiptService
    {
        IDataResult<IList<Receipt>> GetAll();
        IDataResult<IList<Receipt>> GetAllByCompanyId(int companyId);
        IDataResult<IList<Receipt>> GetAllByCategoryId(int categoryId);
        IDataResult<Receipt> GetById(int id);
        IResult Add(Receipt receipt);
        IResult Update(Receipt receipt);
        IResult Delete(Receipt receipt);
    }
}
