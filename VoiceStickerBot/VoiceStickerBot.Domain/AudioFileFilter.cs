namespace VoiceStickerBot.Domain
{
    public class AudioFileFilter
    {
        public string Query { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}