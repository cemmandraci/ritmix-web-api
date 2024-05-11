namespace RitmiX.Entities
{
    public class Music : Base
    {
        public string Name { get; set; }
        public byte[] Mp4File { get; set; }
        public int SingerId { get; set; }
        public Category CategoryName { get; set; }
        public Singer Singer { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}
