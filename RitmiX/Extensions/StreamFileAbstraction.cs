namespace RitmiX.Extensions;

public class StreamFileAbstraction : TagLib.File.IFileAbstraction
{
    public StreamFileAbstraction(string name, Stream stream)
    {
        Name = name;
        ReadStream = stream;
        WriteStream = stream;
    }
    public void CloseStream(Stream stream)
    {
        stream.Close();
    }

    public string Name { get; }
    public Stream ReadStream { get; }
    public Stream WriteStream { get; }
}

public class AudioMetadata
{
    public string Title { get; set; }
    public string[] Artists { get; set; }
    public string Album { get; set; }
    public string[] Genres { get; set; }
}