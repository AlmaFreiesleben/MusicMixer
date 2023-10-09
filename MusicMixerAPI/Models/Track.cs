namespace MusicMixerAPI.Models;

public class Track
{
    public string? Artist { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string[]? IsGoodWith { get; set; }
}