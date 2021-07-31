using System;
using System.Collections.Generic;
using VideoApp.Core.Utilities.Results;
using VideoApp.Entities.DTOs;

namespace VideoApp.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<IList<CategoryDto>> GetList();
        IResult Add(CategoryCreateUpdateDto categoryDto);
        IResult Update(Guid id, CategoryCreateUpdateDto categoryDto);
    }
}
