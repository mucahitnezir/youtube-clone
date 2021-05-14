using System;
using System.Collections.Generic;
using VideoApp.Business.Abstract;
using VideoApp.Core.Entities.Concrete;
using VideoApp.Core.Utilities.Results;
using VideoApp.Core.Utilities.Security.Hashing;
using VideoApp.DataAccess.Abstract;
using VideoApp.Entities.DTOs;

namespace VideoApp.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetById(Guid id)
        {
            return _userDal.Get(u => u.Id == id);
        }

        public User GetByEmail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IResult ChangePassword(Guid userId, ChangePasswordDto changePasswordDto)
        {
            var user = this.GetById(userId);
            if (user == null)
            {
                return new ErrorResult("User not found!");
            }

            if (!HashingHelper.VerifyPasswordHash(changePasswordDto.CurrentPassword, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorResult("Current password is incorrect!");
            }

            HashingHelper.CreatePasswordHash(changePasswordDto.NewPassword, out var passwordHash, out var passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _userDal.Update(user);

            return new SuccessResult("Password updated.");
        }
    }
}