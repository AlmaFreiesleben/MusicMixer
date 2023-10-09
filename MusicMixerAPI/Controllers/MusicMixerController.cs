using Microsoft.AspNetCore.Mvc;
using MusicMixerAPI.Models;

namespace MusicMixerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MusicMixerController : ControllerBase
{
    private static readonly string[] GoesWith = new[]
    {
        "Coffee", "Wine", "Sparkling Water", "Dancing", "Singing Along", "Tears", "Karaoke", "Friends", "Alone Time", "Developing Software"
    };

    private readonly ILogger<MusicMixerController> _logger;

    public MusicMixerController(ILogger<MusicMixerController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetRandomMusicMix")]
    public IEnumerable<Track> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Track
        {
            Artist = "Christine And The Queens",
            Title = "People have been sad",
            Description = "lorem ipsum", 
            IsGoodWith = GoesWith.OrderBy(x => Guid.NewGuid()).Take(4).ToArray()
        })
        .ToArray();
    }
}
