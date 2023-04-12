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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDao _categoryDao;

        public CategoryManager(ICategoryDao categoryDao)
        {
            _categoryDao = categoryDao;
        }

        [AfAuthorizationAspect(roles: "Categories.Add", Priority = 1)]
        [AfValidationAspect(typeof(FvCategoryValidator), Priority = 2)]
        public IResult Add(Category category)
        {
            _categoryDao.Add(category);

            return new SuccessResult(message: Messages.CategoryAdded);
        }

        [AfAuthorizationAspect(roles: "Categories.Delete")]
        public IResult Delete(Category category)
        {
            _categoryDao.Delete(category);

            return new SuccessResult(message: Messages.CategoryDeleted);
        }

        [AfAuthorizationAspect(roles: "Categories.GetAll")]
        public IDataResult<IList<Category>> GetAll()
        {
            var result = _categoryDao.GetAll();

            return new SuccessDataResult<IList<Category>>(data: result);
        }

        [AfAuthorizationAspect(roles: "Categories.GetAllByName")]
        public IDataResult<IList<Category>> GetAllByName(string name)
        {
            var result = _categoryDao.GetAll(c => c.Name.ToLower().Contains(name.ToLower()));

            return new SuccessDataResult<IList<Category>>(data: result);
        }

        [AfAuthorizationAspect(roles: "Categories.GetById")]
        public IDataResult<Category> GetById(int id)
        {
            var result = _categoryDao.Get(c => c.Id == id);

            return new SuccessDataResult<Category>(data: result);
        }

        [AfAuthorizationAspect(roles: "Categories.Update", Priority = 1)]
        [AfValidationAspect(typeof(FvCategoryValidator), Priority = 2)]
        public IResult Update(Category category)
        {
            _categoryDao.Update(category);

            return new SuccessResult(message: Messages.CategoryUpdated);
        }

    }
}
