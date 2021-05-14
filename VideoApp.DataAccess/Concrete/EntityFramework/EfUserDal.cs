using System.Collections.Generic;
using System.Linq;
using VideoApp.Core.DataAccess.EntityFramework;
using VideoApp.Core.Entities.Concrete;
using VideoApp.DataAccess.Abstract;

namespace VideoApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, VideoAppContext>, IUserDal
    {
        public EfUserDal(VideoAppContext context) : base(context)
        {
        }

        public List<OperationClaim> GetClaims(User user)
        {
            var result = from operationClaim in Context.OperationClaims
                join userOperationClaim in Context.UserOperationClaims
                    on operationClaim.Id equals userOperationClaim.OperationClaimId
                where userOperationClaim.UserId == user.Id
                select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}