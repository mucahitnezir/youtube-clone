using VideoApp.Core.Entities;

namespace VideoApp.Entities.DTOs
{
    public class ChangePasswordDto : IDto
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}