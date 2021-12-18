using System;

namespace VoiceStickerBot.EntityModel
{
    public class AudioFile
    {
        public Guid Id { get; set; }
        public Guid TelegramFileId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }

        public AudioFileTag AudioFileTag { get; set; }
    }
}