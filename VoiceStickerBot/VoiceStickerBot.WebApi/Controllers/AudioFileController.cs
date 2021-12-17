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
            var audios = await _service.GetByQuery(audioFileFilter);
            return Ok(audios);
        }
    }
}