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
        IList<PaymentType> GetAll();
        IList<PaymentType> GetAllByName(string name);
        PaymentType GetById(int id);
        void Add(PaymentType paymentType);
        void Update(PaymentType paymentType);
        void Delete(PaymentType paymentType);
    }
}
