using Autofac;
using VideoApp.Business.Abstract;
using VideoApp.Business.Concrete;
using VideoApp.DataAccess.Abstract;
using VideoApp.DataAccess.Concrete.EntityFramework;

namespace VideoApp.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ChannelManager>().As<IChannelService>();
            builder.RegisterType<EfChannelDal>().As<IChannelDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            
            builder.RegisterType<AuthManager>().As<IAuthService>();
        }
    }
}