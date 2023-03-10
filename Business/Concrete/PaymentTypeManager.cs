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
    public class PaymentTypeManager : IPaymentTypeService
    {
        private readonly IPaymentTypeDao _paymentTypeDao;

        public PaymentTypeManager(IPaymentTypeDao paymentTypeDao)
        {
            _paymentTypeDao = paymentTypeDao;
        }

        public void Add(PaymentType paymentType)
        {
            _paymentTypeDao.Add(paymentType);
        }

        public void Delete(PaymentType paymentType)
        {
            _paymentTypeDao.Delete(paymentType);
        }

        public IList<PaymentType> GetAll()
        {
            var result = _paymentTypeDao.GetAll();

            return result;
        }

        public IList<PaymentType> GetAllByName(string name)
        {
            var result = _paymentTypeDao.GetAll(p => p.Name.ToLower().Contains(name.ToLower()));

            return result;
        }

        public PaymentType GetById(int id)
        {
            var result = _paymentTypeDao.Get(p => p.Id ==  id);

            return result;
        }

        public void Update(PaymentType paymentType)
        {
            _paymentTypeDao.Update(paymentType);
        }
    }
}
