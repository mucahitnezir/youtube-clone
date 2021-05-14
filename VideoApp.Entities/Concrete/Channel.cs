using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VideoApp.Core.Entities;
using VideoApp.Core.Entities.Concrete;

namespace VideoApp.Entities.Concrete
{
    public class Channel : EntityBase
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string ImageUrl { get; set; }
        public bool Verified { get; set; }

        public ICollection<Video> Videos { get; set; }
    }
}