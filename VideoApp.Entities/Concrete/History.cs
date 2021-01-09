using System;
using System.ComponentModel.DataAnnotations.Schema;
using VideoApp.Core.Entities;

namespace VideoApp.Entities.Concrete
{
    public class History : EntityBase
    {
        [ForeignKey("Channel")]
        public Guid ChannelId { get; set; }
        public virtual Channel Channel { get; set; }

        [ForeignKey("Video")]
        public Guid VideoId { get; set; }
        public virtual Video Video { get; set; }

        public short Time { get; set; } // last watched second
    }
}