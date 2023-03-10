using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFrameworkCore.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFrameworkCore
{
    public class EfCategoryDao: EfEntityRepositoryBase<Category, BudgetControllerDbDemoContext>, ICategoryDao
    {
    }
}
