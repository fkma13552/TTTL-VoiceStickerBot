using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoiceStickerBot.Domain;
using VoiceStickerBot.EntityModel;

namespace VoiceStickerBot.Service
{
    public interface IAudioFileService
    {
        public Task<AudioFileDto> GetById(Guid guid);
        public Task<IEnumerable<AudioFileDto>> GetPopularAudioFiles();
        public Task<IEnumerable<AudioFileDto>> GetByQuery(AudioFileFilter filter);
        public Task Create(CreateAudioFileDto createAudioFileDto);
    }
}