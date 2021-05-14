using VideoApp.Core.DataAccess.EntityFramework;
using VideoApp.DataAccess.Abstract;
using VideoApp.Entities.Concrete;

namespace VideoApp.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, VideoAppContext>, ICategoryDal
    {
        public EfCategoryDal(VideoAppContext context) : base(context)
        {
        }
    }
}