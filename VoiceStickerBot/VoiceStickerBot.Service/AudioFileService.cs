using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VoiceStickerBot.Data.Abstract;
using VoiceStickerBot.Domain;

namespace VoiceStickerBot.Service
{
    public class AudioFileService: IAudioFileService
    {
        private readonly IAudioFileRepository _audioFileRepository;
        private readonly IAudioFileTagRepository _audioFileTagRepository;
        private readonly IMapper _mapper;

        public AudioFileService(IAudioFileRepository audioFileRepositor, IAudioFileTagRepository audioFileTagRepository, IMapper mapper)
        {
            _audioFileRepository = audioFileRepositor;
            _audioFileTagRepository = audioFileTagRepository;
            _mapper = mapper;
        }

        public async Task<AudioFileDto> GetById(Guid id)
        {
            var audioFile = await _audioFileRepository.GetById(id);
            return audioFile.ToDto();
        }

        public Task<IEnumerable<AudioFileDto>> GetPopularAudioFiles()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AudioFileDto>> GetByQuery(AudioFileFilter filter)
        {
            var filesTags = _audioFileTagRepository.Get<int>().Include("AudioFile").Include("Tag");

            var result = filesTags
                    .Where(
                        f => 
                            f.Tag.Name.Contains(filter.Query.ToLower()) ||
                             f.AudioFile.Name.Contains(filter.Query.ToLower()));
            if (filter.Skip > 0)
            {
                result = result.Skip(filter.Skip);
            }

            if (filter.Take > 0)
            {
                result = result.Take(filter.Take);
            }
            var list = await result.Select(f => f.AudioFile).ToListAsync();

            return _mapper.Map<List<AudioFileDto>>(list);
        }
    }
}