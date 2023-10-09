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
        ("Christine and the Queens", "People I've Been Sad", "Best number ever"), 
        ("Queen", "I Want To Break Free", "Best Music Video"),
        ("Elton John", "Tiny Dancer", "The lyric 'Tiny dancer in my hand' always make me smile"), 
        ("Nick Cave and the bad seeds", "The wild rose", "what a wonderful song"),
        ("Jada", "Nudes", "Such a wonderful danish singer from Næver"),
        ("Rina Mushonga", "NarciscO", "Dansable and energetic always give a great mood")
    };

    [HttpGet("get_random_music_mix")]
    public IEnumerable<Track> GetRandomMusicList()
    {
        return Tracks.Select(track => new Track
        {
            Artist = track.artist,
            Title = track.title,
            Description = track.description, 
            IsGoodWith = GoesWith.OrderBy(x => Guid.NewGuid()).Take(3).ToArray()
        })
        .ToArray();
    }

    [HttpGet("get_random_track")]
    public Track GetTrack()
    {
        var track = Tracks[Random.Shared.Next(Tracks.Length)];
        return new Track() {
            Artist = track.artist, 
            Title = track.title, 
            Description = track.description, 
            IsGoodWith = GoesWith.OrderBy(x => Guid.NewGuid()).Take(3).ToArray()
        };
    }
}
