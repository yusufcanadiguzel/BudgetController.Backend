using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaimDto>> GetOperationClaims(User user);
        IDataResult<User> GetByMail(string mail);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
