using VideoApp.Core.DataAccess;
using VideoApp.Entities.Concrete;

namespace VideoApp.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        
    }
}