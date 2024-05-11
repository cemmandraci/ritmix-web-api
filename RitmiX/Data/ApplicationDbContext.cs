using Microsoft.EntityFrameworkCore;
using RitmiX.Entities;

namespace RitmiX.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Music> Musics { get; set; }
        public DbSet<MusicHistory> MusicHistories { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
