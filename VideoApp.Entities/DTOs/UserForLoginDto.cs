using VideoApp.Core.Entities;

namespace VideoApp.Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}