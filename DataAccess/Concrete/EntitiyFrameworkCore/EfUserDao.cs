using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFrameworkCore.Contexts;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFrameworkCore
{
    public class EfUserDao : EfEntityRepositoryBase<User, BudgetControllerDbDemoContext>, IUserDao
    {
        public List<OperationClaimDto> GetOperationClaims(User user)
        {
            using (var context = new BudgetControllerDbDemoContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaimDto { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();
            }
        }
    }
}
