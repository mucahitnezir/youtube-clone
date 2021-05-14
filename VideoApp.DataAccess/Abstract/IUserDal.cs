using System.Collections.Generic;
using VideoApp.Core.DataAccess;
using VideoApp.Core.Entities.Concrete;

namespace VideoApp.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}