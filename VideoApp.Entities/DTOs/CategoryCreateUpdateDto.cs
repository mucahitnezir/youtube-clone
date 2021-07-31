using VideoApp.Core.Entities;

namespace VideoApp.Entities.DTOs
{
    public class CategoryCreateUpdateDto : IDto
    {
        public string Name { get; set; }
    }
}
