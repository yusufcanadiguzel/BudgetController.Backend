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
    public class ReceiptManager : IReceiptService
    {
        private readonly IReceiptDao _receiptDao;

        public ReceiptManager(IReceiptDao receiptDao)
        {
            _receiptDao = receiptDao;
        }

        [AfAuthorizationAspect(roles: "Receipts.Add", Priority = 1)]
        [AfValidationAspect(typeof(FvReceiptValidator), Priority = 2)]
        public IResult Add(Receipt receipt)
        {
            _receiptDao.Add(receipt);

            return new SuccessResult(message: Messages.ReceiptAdded);
        }

        [AfAuthorizationAspect(roles: "Receipts.Delete")]
        public IResult Delete(Receipt receipt)
        {
            _receiptDao.Delete(receipt);

            return new SuccessResult(message: Messages.ReceiptDeleted);
        }

        [AfAuthorizationAspect(roles: "Receipts.GetAll")]
        public IDataResult<IList<Receipt>> GetAll()
        {
            var result = _receiptDao.GetAll();

            return new SuccessDataResult<IList<Receipt>>(data: result);
        }

        [AfAuthorizationAspect(roles: "Receipts.GetAllByCategory")]
        public IDataResult<IList<Receipt>> GetAllByCategoryId(int categoryId)
        {
            var result = _receiptDao.GetAll(r => r.CategoryId == categoryId);

            return new SuccessDataResult<IList<Receipt>>(data: result);
        }

        [AfAuthorizationAspect(roles: "Receipts.GetAllByCompanyId")]
        public IDataResult<IList<Receipt>> GetAllByCompanyId(int companyId)
        {
            var result = _receiptDao.GetAll(r => r.CompanyId == companyId);

            return new SuccessDataResult<IList<Receipt>>(data: result);
        }

        [AfAuthorizationAspect(roles: "Receipts.GetById")]
        public IDataResult<Receipt> GetById(int id)
        {
            var result = _receiptDao.Get(r => r.Id == id);

            return new SuccessDataResult<Receipt>(data: result);
        }

        [AfAuthorizationAspect(roles: "Receipts.Update", Priority = 1)]
        [AfValidationAspect(typeof(FvReceiptValidator), Priority = 2)]
        public IResult Update(Receipt receipt)
        {
            _receiptDao.Update(receipt);

            return new SuccessResult(message: Messages.ReceiptUpdated);
        }
    }
}
