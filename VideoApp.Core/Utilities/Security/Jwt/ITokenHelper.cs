using System.Collections.Generic;
using VideoApp.Core.Entities.Concrete;

namespace VideoApp.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}