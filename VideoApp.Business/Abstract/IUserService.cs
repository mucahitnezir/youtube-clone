using System;
using System.Collections.Generic;
using VideoApp.Core.Entities.Concrete;
using VideoApp.Core.Utilities.Results;
using VideoApp.Entities.DTOs;

namespace VideoApp.Business.Abstract
{
    public interface IUserService
    {
        User GetById(Guid id);
        User GetByEmail(string email);
        IResult Add(User user);
        List<OperationClaim> GetClaims(User user);
        IResult ChangePassword(Guid userId, ChangePasswordDto changePasswordDto);
    }
}