using VideoApp.Business.Abstract;
using VideoApp.Core.Entities.Concrete;
using VideoApp.Core.Utilities.Results;
using VideoApp.Core.Utilities.Security.Hashing;
using VideoApp.Core.Utilities.Security.Jwt;
using VideoApp.Entities.DTOs;

namespace VideoApp.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out var passwordHash, out var passwordSalt);

            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            return _userService.Add(user).Success
                ? new SuccessDataResult<User>(user, "User created.")
                : new ErrorDataResult<User>(null, "User cannot created");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(null, "User not found");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(null, "Invalid password");
            }

            if (userToCheck.Status == false)
            {
                return new ErrorDataResult<User>(null, "User not confirmed");
            }

            return new SuccessDataResult<User>(userToCheck, "Login successful");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email) != null)
            {
                return new SuccessResult("Already exist");
            }

            return new ErrorResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Access token is created.");
        }
    }
}
