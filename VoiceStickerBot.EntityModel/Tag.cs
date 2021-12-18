using System;

namespace VoiceStickerBot.EntityModel
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public AudioFileTag AudioFileTag { get; set; }
    }
}