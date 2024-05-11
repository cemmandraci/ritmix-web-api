namespace RitmiX.Entities
{
    public class MusicHistory : Base
    {
        public int MusicId { get; set; }
        public Music Music { get; set; }
    }
}
