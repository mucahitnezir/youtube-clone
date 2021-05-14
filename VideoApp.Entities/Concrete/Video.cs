using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VideoApp.Core.Entities;

namespace VideoApp.Entities.Concrete
{
    public enum VideoVisibility
    {
        Public,
        Private,
        Unlisted
    }

    public class Video : EntityBase
    {
        [ForeignKey("Channel")]
        public Guid ChannelId { get; set; }
        public virtual Channel Channel { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string StreamId { get; set; } // Cloudflare Stream Id
        public VideoVisibility Visibility { get; set; }
        public DateTime PublishDate { get; set; }
        public uint Views { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<PlaylistVideo> PlaylistVideos { get; set; }
    }
}