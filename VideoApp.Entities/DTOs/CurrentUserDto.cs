using System;
using VideoApp.Core.Entities;

namespace VideoApp.Entities.DTOs
{
    public class CurrentUserDto : IDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}