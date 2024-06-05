using RitmiX.Abstractions;
using RitmiX.Data;
using RitmiX.Entities;
using RitmiX.Extensions;
using RitmiX.Models;

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
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var fileAbstraction = new StreamFileAbstraction(file.FileName, memoryStream, memoryStream);
            var tagFile = TagLib.File.Create(fileAbstraction);

            var metadata = new AudioMetadata()
            {
                Title = tagFile.Tag.Title,
                Artists = tagFile.Tag.Performers,
                Album = tagFile.Tag.Album,
                Genres = tagFile.Tag.Genres
            };
            
            //artist kontorlü yapmak gerek
            //kategori kontrolü yapmak gerek

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
    }
}
