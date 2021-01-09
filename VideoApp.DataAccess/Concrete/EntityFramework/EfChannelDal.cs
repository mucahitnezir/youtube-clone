using VideoApp.Core.DataAccess.EntityFramework;
using VideoApp.DataAccess.Abstract;
using VideoApp.Entities.Concrete;

namespace VideoApp.DataAccess.Concrete.EntityFramework
{
    public class EfChannelDal : EfEntityRepositoryBase<Channel, VideoAppContext>, IChannelDal
    {
    }
}