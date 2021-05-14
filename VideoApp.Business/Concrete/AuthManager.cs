using System;
using VideoApp.Business.Abstract;
using VideoApp.Core.Entities.Concrete;
using VideoApp.Core.Utilities.Results;
using VideoApp.Core.Utilities.Security.Hashing;
using VideoApp.Entities.DTOs;

namespace VideoApp.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "User created.");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email) != null)
            {
                return new SuccessResult("Already exist");
            }

            return new ErrorResult();
        }
    }
}