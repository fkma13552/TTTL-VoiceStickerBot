using AutoMapper;
using VoiceStickerBot.Domain;
using VoiceStickerBot.EntityModel;

namespace VoiceStickerBot.Service
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<AudioFileDto, AudioFile>().ReverseMap();
            CreateMap<TagDto, Tag>().ReverseMap();
            CreateMap<AudioFileTagDto, AudioFileTag>().ReverseMap();
        }
    }
}