using System;
using System.Collections.Generic;
using VideoApp.Business.Abstract;
using VideoApp.Core.Utilities.Results;
using VideoApp.DataAccess.Abstract;
using VideoApp.Entities.Concrete;
using VideoApp.Entities.DTOs;

namespace VideoApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<IList<Category>> GetList()
        {
            var categoryList = _categoryDal.GetList();
            return new SuccessDataResult<IList<Category>>(categoryList);
        }

        public IResult Add(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _categoryDal.Add(category);
            return new SuccessResult("Category created.");
        }

        public IResult Update(Guid id, CategoryDto categoryDto)
        {
            var category = new Category
            {
                Id = id,
                Name = categoryDto.Name,
                UpdatedAt = DateTime.Now
            };

            _categoryDal.Update(category);
            return new SuccessResult("Category updated.");
        }
    }
}