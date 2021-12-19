using Microsoft.EntityFrameworkCore;
using VoiceStickerBot.EntityModel;

namespace VoiceStickerBot.Data
{
    public class VoiceStickerContext: DbContext
    {
        public DbSet<AudioFile> AudioFiles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AudioFileTag> AudioFileTags { get; set; }

        public VoiceStickerContext(DbContextOptions options):base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=VoiceStickerDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}