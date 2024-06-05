using Microsoft.AspNetCore.Mvc;
using RitmiX.Abstractions;
using RitmiX.Models;

namespace RitmiX.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadAudio(MusicRequestModel request)
        {
            var metadata = await _musicService.GetMetadata(request.File);
            return Ok(metadata);
        }
        
        
    }
}
