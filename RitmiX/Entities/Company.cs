namespace RitmiX.Entities
{
    public class Company : Base
    {
        public string Name { get; set; }
        public ICollection<Music> Musics { get; set; }
    }
}
