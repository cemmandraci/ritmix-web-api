using RitmiX.Abstractions;
using RitmiX.Data;
using RitmiX.Entities;
using RitmiX.Extensions;
using RitmiX.Models;
using System.Formats.Tar;

namespace RitmiX.Concretes
{
    public class MusicService : IMusicService
    {
        private readonly ApplicationDbContext _context;

        public MusicService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MusicResponseModel> GetMetadata(IFormFile file)
        {

            byte[] fileData = File.ReadAllBytes(file.FileName);

            using (MemoryStream memoryStream = new MemoryStream(fileData))
            {
                // StreamFileAbstraction oluştur
                var abstraction = new StreamFileAbstraction(file.FileName, memoryStream);
                var fileN = TagLib.File.Create(abstraction);
                //    await file.CopyToAsync(memoryStream);
                //   memoryStream.Position = 0; 
                var metadata = new AudioMetadata()
                {
                    Title = fileN.Tag.Title,
                    Artists = fileN.Tag.Performers,
                    Album = fileN.Tag.Album,
                    Genres = fileN.Tag.Genres
                };
                var music = new Music()
                {
                    Name = metadata.Title ?? file.FileName,
                    Mp4File = memoryStream.ToArray(),
                };

                _context.Musics.Add(music);
                await _context.SaveChangesAsync();

                var responseMusic = new MusicResponseModel()
                {
                    Id = music.Id,
                    Name = music.Name,
                    Mp4File = music.Mp4File,
                    SingerName = "deneme"
                };
                return responseMusic;
            }



            //artist kontorlü yapmak gerek
            //kategori kontrolü yapmak gerek




        }
    }
}
