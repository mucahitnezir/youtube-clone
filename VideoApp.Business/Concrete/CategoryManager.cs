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

        public IResult Add(CategoryCreateUpdateDto categoryDto)
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

        public IResult Update(Guid id, CategoryCreateUpdateDto categoryDto)
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
