using System;
using VideoApp.Core.Entities;

namespace VideoApp.Entities.DTOs
{
    public class CurrentUserDto : DtoBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
