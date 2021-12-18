using VoiceStickerBot.Data.Abstract;
using VoiceStickerBot.EntityModel;

namespace VoiceStickerBot.Data.Repositories
{
    public class AudioFileRepository: EntityRepository<AudioFile>, IAudioFileRepository
    {
        public AudioFileRepository(VoiceStickerContext context) : base(context)
        {
        }
    }
}