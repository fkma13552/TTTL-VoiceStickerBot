using System;

namespace VoiceStickerBot.Domain
{
    public class CreateAudioFileDto
    {
        public string TelegramFileId { get; set; }
        public string Name { get; set; }
    }
}