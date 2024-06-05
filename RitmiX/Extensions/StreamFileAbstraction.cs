namespace RitmiX.Extensions;

public class StreamFileAbstraction : TagLib.File.IFileAbstraction
{
    public StreamFileAbstraction(string name, Stream readStream, Stream writeStream)
    {
        Name = name;
        ReadStream = readStream;
        WriteStream = writeStream;
    }
    public void CloseStream(Stream stream)
    {
        //
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