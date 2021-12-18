using System;

namespace VoiceStickerBot.Domain
{
    public class CreateAudioFileDto
    {
        public Guid TelegramFileId { get; set; }
        public string Name { get; set; }
    }
}