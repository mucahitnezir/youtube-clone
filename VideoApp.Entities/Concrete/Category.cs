using System;
using System.Collections.Generic;
using VideoApp.Core.Entities;

namespace VideoApp.Entities.Concrete
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}