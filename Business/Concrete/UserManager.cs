using Business.Abstract;
using Business.Constants.Concrete;
using Business.Validation.FluentValidation;
using Core.Aspects.Validation.Autofac;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDao _userDao;

        public UserManager(IUserDao userDao)
        {
            _userDao = userDao;
        }

        [AfValidationAspect(typeof(FvUserValidator), Priority = 1)]
        public IResult Add(User user)
        {
            _userDao.Add(user);

            return new SuccessResult(message: Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDao.Delete(user);

            return new SuccessResult(message: Messages.UserDeleted);
        }

        public IDataResult<User> GetByMail(string mail)
        {
            var result = _userDao.Get(u => u.Email.ToLower().Contains(mail.ToLower()));

            return new SuccessDataResult<User>(data: result);
        }

        public IDataResult<List<OperationClaimDto>> GetOperationClaims(User user)
        {
            var result = _userDao.GetOperationClaims(user);

            return new SuccessDataResult<List<OperationClaimDto>>(data: result);
        }

        [AfValidationAspect(typeof(FvUserValidator), Priority = 1)]
        public IResult Update(User user)
        {
            _userDao.Update(user);

            return new SuccessResult(message: Messages.UserUpdated);
        }
    }
}
