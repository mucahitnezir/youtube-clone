using System;
using System.Collections.Generic;
using VideoApp.Core.Utilities.Results;
using VideoApp.Entities.Concrete;
using VideoApp.Entities.Dtos;

namespace VideoApp.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<IList<Category>> GetList();
        IResult Add(CategoryDto categoryDto);
        IResult Update(Guid id, CategoryDto categoryDto);
    }
}