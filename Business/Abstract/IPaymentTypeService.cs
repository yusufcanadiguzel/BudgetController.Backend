using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaymentTypeService
    {
        IDataResult<IList<PaymentType>> GetAll();
        IDataResult<IList<PaymentType>> GetAllByName(string name);
        IDataResult<PaymentType> GetById(int id);
        IResult Add(PaymentType paymentType);
        IResult Update(PaymentType paymentType);
        IResult Delete(PaymentType paymentType);
    }
}
