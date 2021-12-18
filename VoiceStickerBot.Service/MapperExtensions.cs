using System;
using System.Collections.Generic;
using AutoMapper;
using VoiceStickerBot.Domain;
using VoiceStickerBot.EntityModel;

namespace VoiceStickerBot.Service
{
    public static class MapperExtensions
    {
        public static AudioFileDto ToDto(this AudioFile entity)
        {
            return Mapper<AudioFile, AudioFileDto>(entity, cfg =>
            {
                cfg.CreateMap<AudioFile, AudioFileDto>();
            });
        }
        
        public static AudioFileTagDto ToDto(this AudioFileTag entity)
        {
            return Mapper<AudioFileTag, AudioFileTagDto>(entity, cfg =>
            {
                cfg.CreateMap<AudioFileTag, AudioFileTagDto>();
            });
        }
        
        public static TagDto ToDto(this Tag entity)
        {
            return Mapper<Tag, TagDto>(entity, cfg =>
            {
                cfg.CreateMap<Tag, TagDto>();
            });
        }

        private static TDestination Mapper<TSource, TDestination>(
            this TSource source,
            Action<IMapperConfigurationExpression> configure)
        {
            var config = new MapperConfiguration(configure);
            var mapper = config.CreateMapper();
            var destination = mapper.Map<TDestination>(source);
            return destination;
        }
    }
}