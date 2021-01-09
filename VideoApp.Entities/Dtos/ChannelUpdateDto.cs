using VideoApp.Core.Entities;

namespace VideoApp.Entities.Dtos
{
    public class ChannelUpdateDto : IDto
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
    }
}