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
    public class ReceiptManager : IReceiptService
    {
        private readonly IReceiptDao _receiptDao;

        public ReceiptManager(IReceiptDao receiptDao)
        {
            _receiptDao = receiptDao;
        }

        public void Add(Receipt receipt)
        {
            _receiptDao.Add(receipt);
        }

        public void Delete(Receipt receipt)
        {
            _receiptDao.Delete(receipt);
        }

        public IList<Receipt> GetAll()
        {
            var result = _receiptDao.GetAll();

            return result;
        }

        public IList<Receipt> GetAllByCategoryId(int categoryId)
        {
            var result = _receiptDao.GetAll(r => r.CategoryId == categoryId);

            return result;
        }

        public IList<Receipt> GetAllByCompanyId(int companyId)
        {
            var result = _receiptDao.GetAll(r => r.CompanyId == companyId);

            return result;
        }

        public Receipt GetById(int id)
        {
            var result = _receiptDao.Get(r => r.Id == id);

            return result;
        }

        public void Update(Receipt receipt)
        {
            _receiptDao.Update(receipt);
        }
    }
}
