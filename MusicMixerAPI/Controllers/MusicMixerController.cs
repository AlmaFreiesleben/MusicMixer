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

    private static readonly (string artist,string title,string description)[] Tracks = new[]
    {
        ("Christine and the Queens", "The Walker", "The number I sang the most during COVID-19"), 
        ("Queen", "I Want To Break Free", "Music video makes me incredibly happy"),
        ("Elton John", "Tiny Dancer", "The lyric 'tiny dancer in my hand' always make me smile"), 
        ("Nick Cave and the bad seeds", "The wild rose", "Reminds me of listening in on my mom singing, as a kid"),
        ("Jada", "Sure", "One of my favorite danish singers"),
        ("Rina Mushonga", "NarciscO", "My sisters and I heard this on repeat across the Bay of Biscay")
    };

    [HttpGet("get_random_music_mix")]
    public IEnumerable<Track> GetRandomMusicList()
    {
        int i = Random.Shared.Next(1,GoesWith.Length / 2);

        return Tracks.Select(track => new Track
        {
            Artist = track.artist,
            Title = track.title,
            Description = track.description, 
            IsGoodWith = GoesWith.OrderBy(x => Guid.NewGuid()).Take(i).ToArray()
        })
        .ToArray();
    }

    [HttpGet("get_random_track")]
    public Track GetTrack()
    {
        var track = Tracks[Random.Shared.Next(Tracks.Length)];
        int i = Random.Shared.Next(1,GoesWith.Length / 2);
        
        return new Track() {
            Artist = track.artist, 
            Title = track.title, 
            Description = track.description, 
            IsGoodWith = GoesWith.OrderBy(x => Guid.NewGuid()).Take(i).ToArray()
        };
    }
}
