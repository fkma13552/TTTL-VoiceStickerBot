using VoiceStickerBot.Data.Abstract;
using VoiceStickerBot.EntityModel;

namespace VoiceStickerBot.Data.Repositories
{
    public class TagRepository: EntityRepository<Tag>, ITagRepository
    {
        public TagRepository(VoiceStickerContext context) : base(context)
        {
        }
    }
}