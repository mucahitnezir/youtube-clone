using VideoApp.Core.Entities.Concrete;
using VideoApp.Core.Utilities.Results;
using VideoApp.Entities.DTOs;

namespace VideoApp.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IResult UserExists(string email);
    }
}