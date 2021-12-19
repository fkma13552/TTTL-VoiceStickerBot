using System;

namespace VoiceStickerBot.Domain
{
    public class AudioFileDto
    {
        public Guid Id { get; set; }
        public string TelegramFileId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}