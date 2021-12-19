using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoiceStickerBot.EntityModel
{
    public class AudioFile
    {
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(70)")]
        public string TelegramFileId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }

        public AudioFileTag AudioFileTag { get; set; }
    }
}