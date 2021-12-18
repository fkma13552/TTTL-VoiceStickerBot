using System;

namespace VoiceStickerBot.EntityModel
{
    public class AudioFileTag
    {
        public Guid Id { get; set; }
        public Guid AudioFileId { get; set; }
        public Guid TagId { get; set; }
        
        public AudioFile AudioFile { get; set; }
        public Tag Tag { get; set; }
    }
}