using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Security.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.Abstract
{
    public interface ITokenHelper : IHelper
    {
        AccessToken CreateAccessToken(User user, List<OperationClaimDto> operationClaims);
    }
}
