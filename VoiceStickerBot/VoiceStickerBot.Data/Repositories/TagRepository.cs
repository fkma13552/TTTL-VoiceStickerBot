using VoiceStickerBot.Data.Abstract;
using VoiceStickerBot.EntityModel;

namespace VoiceStickerBot.Data.Repositories
{
    public class TagRepository: EntityRepository<Tag>, ITagRepository
    {
        public TagRepository(MyContext context) : base(context)
        {
        }
    }
}