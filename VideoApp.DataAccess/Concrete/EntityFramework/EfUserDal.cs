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
    }
}