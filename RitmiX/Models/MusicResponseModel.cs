namespace RitmiX.Models;

public class MusicResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] Mp4File { get; set; }
    public string SingerName { get; set; }
}