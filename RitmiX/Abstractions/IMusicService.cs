using RitmiX.Extensions;
using RitmiX.Models;

namespace RitmiX.Abstractions
{
    public interface IMusicService
    {
        Task<MusicResponseModel> GetMetadata(IFormFile file);
    }
}
