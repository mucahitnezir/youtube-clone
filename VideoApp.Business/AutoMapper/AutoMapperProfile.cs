using AutoMapper;
using VideoApp.Core.Entities.Concrete;
using VideoApp.Entities.Concrete;
using VideoApp.Entities.DTOs;

namespace VideoApp.Business.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateUpdateDto, Category>();

            CreateMap<User, CurrentUserDto>();
        }
    }
}
