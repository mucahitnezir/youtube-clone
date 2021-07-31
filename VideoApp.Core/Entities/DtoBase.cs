using System;

namespace VideoApp.Core.Entities
{
    public abstract class DtoBase : IDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
