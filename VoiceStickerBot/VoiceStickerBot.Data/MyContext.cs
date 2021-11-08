using Microsoft.EntityFrameworkCore;
using VoiceStickerBot.EntityModel;

namespace VoiceStickerBot.Data
{
    public class MyContext: DbContext
    {
        public DbSet<AudioFile> AudioFiles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AudioFileTag> AudioFileTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-R9KO1GP;Database=VoiceStickerDb;Trusted_Connection=True;");
        }
    }
}