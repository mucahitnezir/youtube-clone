using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VideoApp.Core.Entities;

namespace VideoApp.Entities.Concrete
{
    public enum PlaylistVisibility
    {
        Public,
        Private,
        Unlisted
    }

    public class Playlist : EntityBase
    {
        [ForeignKey("Channel")]
        public Guid ChannelId { get; set; }
        public virtual Channel Channel { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public PlaylistVisibility Visibility { get; set; }

        public ICollection<PlaylistVideo> PlaylistVideos { get; set; }
    }
}