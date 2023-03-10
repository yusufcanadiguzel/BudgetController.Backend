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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDao _categoryDao;

        public CategoryManager(ICategoryDao categoryDao)
        {
            _categoryDao = categoryDao;
        }

        public void Add(Category category) => _categoryDao.Add(category);

        public void Delete(Category category) => _categoryDao.Delete(category);

        public IList<Category> GetAll()
        {
            var result = _categoryDao.GetAll();

            return result;
        }

        public IList<Category> GetAllByName(string name)
        {
            var result = _categoryDao.GetAll(c => c.Name.ToLower().Contains(name.ToLower()));

            return result;
        }

        public Category GetById(int id)
        {
            var result = _categoryDao.Get(c => c.Id == id);

            return result;
        }

        public void Update(Category category) => _categoryDao.Update(category);
    }
}
