using VideoApp.Core.DataAccess;
using VideoApp.Core.Entities.Concrete;

namespace VideoApp.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        
    }
}