using System;
using System.Collections.Generic;
using VideoApp.Core.Utilities.Results;
using VideoApp.Entities.Concrete;
using VideoApp.Entities.DTOs;

namespace VideoApp.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<IList<CategoryDto>> GetList();
        IDataResult<Category> GetById(Guid id);
        IResult Add(CategoryCreateUpdateDto categoryDto);
        IResult Update(Guid id, CategoryCreateUpdateDto categoryDto);
    }
}
