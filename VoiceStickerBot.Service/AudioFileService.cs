using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using VoiceStickerBot.Data.Abstract;
using VoiceStickerBot.Domain;
using VoiceStickerBot.EntityModel;

namespace VoiceStickerBot.Service
{
    public class AudioFileService: IAudioFileService
    {
        private readonly IAudioFileRepository _audioFileRepository;
        private readonly IAudioFileTagRepository _audioFileTagRepository;
        private readonly IMapper _mapper;
        private readonly string _includePropertiesForGetByQueryAudioFiles =
            $"{nameof(AudioFileTag)},{nameof(AudioFileTag)}.{nameof(Tag)}";

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
            var audioFile = _audioFileRepository.Get<int>(
                filter.Skip, 
                filter.Take, 
                _includePropertiesForGetByQueryAudioFiles,
                file => 
                    file.AudioFileTag.Tag.Name.Contains(filter.Query.ToLower()) ||
                    file.Name.Contains(filter.Query.ToLower()));

            return _mapper.Map<List<AudioFileDto>>(audioFile);
        }

        public async Task Create(CreateAudioFileDto createAudioFileDto)
        {
            var newAudioFile = new AudioFile
            {
                Id = Guid.NewGuid(),
                TelegramFileId = createAudioFileDto.TelegramFileId,
                Name = createAudioFileDto.Name,
                CreatedOn = DateTime.Now
            };

            await _audioFileRepository.Create(newAudioFile);
        }
    }
}