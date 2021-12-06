using System;
using System.Threading.Tasks;
using VoiceStickerBot.Data.Abstract;
using VoiceStickerBot.EntityModel;

namespace VoiceStickerBot.Data.Repositories
{
    public class AudioFileTagRepository: EntityRepository<AudioFileTag>, IAudioFileTagRepository
    {
        public AudioFileTagRepository(VoiceStickerContext context) : base(context)
        {
        }
    }
}