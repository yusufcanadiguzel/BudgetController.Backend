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
        IList<Receipt> GetAll();
        IList<Receipt> GetAllByCompanyId(int companyId);
        IList<Receipt> GetAllByCategoryId(int categoryId);
        Receipt GetById(int id);
        void Add(Receipt receipt);
        void Update(Receipt receipt);
        void Delete(Receipt receipt);
    }
}
