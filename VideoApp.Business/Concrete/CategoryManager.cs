using System;
using System.Collections.Generic;
using AutoMapper;
using VideoApp.Business.Abstract;
using VideoApp.Core.Utilities.Results;
using VideoApp.DataAccess.Abstract;
using VideoApp.Entities.Concrete;
using VideoApp.Entities.DTOs;

namespace VideoApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public IDataResult<IList<CategoryDto>> GetList()
        {
            var categoryList = _categoryDal.GetList();
            var categories = _mapper.Map<IList<CategoryDto>>(categoryList);
            return new SuccessDataResult<IList<CategoryDto>>(categories);
        }

        public IDataResult<Category> GetById(Guid id)
        {
            var category = _categoryDal.Get(c => c.Id == id);
            if (category == null)
            {
                return new ErrorDataResult<Category>(null, "Category not found!");
            }

            return new SuccessDataResult<Category>(category);
        }

        public IResult Add(CategoryCreateUpdateDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _categoryDal.Add(category);

            return new SuccessResult("Category created.");
        }

        public IResult Update(Guid id, CategoryCreateUpdateDto categoryDto)
        {
            var result = GetById(id);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }

            var category = result.Data;
            category.Name = categoryDto.Name;
            _categoryDal.Update(category);

            return new SuccessResult("Category updated.");
        }
    }
}
