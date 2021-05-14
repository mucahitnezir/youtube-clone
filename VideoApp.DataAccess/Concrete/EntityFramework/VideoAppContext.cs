using Microsoft.EntityFrameworkCore;
using VideoApp.Core.Entities.Concrete;
using VideoApp.Entities.Concrete;

namespace VideoApp.DataAccess.Concrete.EntityFramework
{
    public class VideoAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Feeling> Feelings { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistVideo> PlaylistVideo { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Video> Videos { get; set; }

        public VideoAppContext(DbContextOptions<VideoAppContext> options) : base(options)
        {
            
        }
    }
}