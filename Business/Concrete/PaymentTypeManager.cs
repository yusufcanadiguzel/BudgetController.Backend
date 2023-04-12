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
    public class PaymentTypeManager : IPaymentTypeService
    {
        private readonly IPaymentTypeDao _paymentTypeDao;

        public PaymentTypeManager(IPaymentTypeDao paymentTypeDao)
        {
            _paymentTypeDao = paymentTypeDao;
        }

        [AfAuthorizationAspect(roles: "PaymentTypes.Add", Priority = 1)]
        [AfValidationAspect(typeof(FvPaymentTypeValidator), Priority = 2)]
        public IResult Add(PaymentType paymentType)
        {
            _paymentTypeDao.Add(paymentType);

            return new SuccessResult(message: Messages.PaymentTypeAdded);
        }

        [AfAuthorizationAspect(roles: "PaymentTypes.Delete")]
        public IResult Delete(PaymentType paymentType)
        {
            _paymentTypeDao.Delete(paymentType);

            return new SuccessResult(message: Messages.PaymentTypeDeleted);
        }

        [AfAuthorizationAspect(roles: "PaymentTypes.GetAll")]
        public IDataResult<IList<PaymentType>> GetAll()
        {
            var result = _paymentTypeDao.GetAll();

            return new SuccessDataResult<IList<PaymentType>>(data: result);
        }

        [AfAuthorizationAspect(roles: "PaymentTypes.GetAllByName")]
        public IDataResult<IList<PaymentType>> GetAllByName(string name)
        {
            var result = _paymentTypeDao.GetAll(p => p.Name.ToLower().Contains(name.ToLower()));

            return new SuccessDataResult<IList<PaymentType>>(data: result);
        }

        [AfAuthorizationAspect(roles: "PaymentTypes.GetById")]
        public IDataResult<PaymentType> GetById(int id)
        {
            var result = _paymentTypeDao.Get(p => p.Id ==  id);

            return new SuccessDataResult<PaymentType>(data: result);
        }

        [AfAuthorizationAspect(roles: "PaymentTypes.Update", Priority = 1)]
        [AfValidationAspect(typeof(FvPaymentTypeValidator), Priority = 2)]
        public IResult Update(PaymentType paymentType)
        {
            _paymentTypeDao.Update(paymentType);

            return new SuccessResult(message: Messages.PaymentTypeUpdated);
        }
    }
}
