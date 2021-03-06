using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoiceStickerBot.Domain;
using VoiceStickerBot.EntityModel;
using VoiceStickerBot.Service;

namespace VoiceStickerBot.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AudioFileController: ControllerBase
    {
        private readonly IAudioFileService _service;

        public AudioFileController(IAudioFileService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetByQuery([FromQuery] AudioFileFilter audioFileFilter)
        {
            if (audioFileFilter.Take < 1 || string.IsNullOrWhiteSpace(audioFileFilter.Query))
            {
                return BadRequest();
            }
            var audios = await _service.GetByQuery(audioFileFilter);
            return Ok(audios);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dto = await _service.GetById(id);
            if (dto is null)
            {
                return NoContent();
            }

            return Ok(dto);
        }

        [HttpPost]
        public async Task Create([FromBody] CreateAudioFileDto createAudioFileDto)
        {
            await _service.Create(createAudioFileDto);
        }
    }
}