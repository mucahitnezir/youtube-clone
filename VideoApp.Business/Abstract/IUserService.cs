using System;
using VideoApp.Core.Entities.Concrete;
using VideoApp.Core.Utilities.Results;

namespace VideoApp.Business.Abstract
{
    public interface IUserService
    {
        User GetById(Guid id);
        User GetByEmail(string email);
        IResult Add(User user);
    }
}