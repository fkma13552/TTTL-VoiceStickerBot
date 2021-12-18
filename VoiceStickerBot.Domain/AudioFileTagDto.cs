using System;

namespace VoiceStickerBot.Domain
{
    public class AudioFileTagDto
    {
        public Guid Id { get; set; }
        public Guid AudioFileId { get; set; }
        public Guid TagId { get; set; }
        
        public AudioFileDto AudioFile { get; set; }
        public TagDto Tag { get; set; }
    }
}