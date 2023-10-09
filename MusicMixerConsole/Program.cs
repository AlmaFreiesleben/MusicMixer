using System.Net.Http.Headers;

namespace HttpClientSample
{
    public class Track
    {
        public string? Artist { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string[]? IsGoodWith { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowTrack(Track track)
        {
            Console.WriteLine($"Artist: {track.Artist}\tTitle: " +
                $"{track.Title}\tDescription: {track.Description}");
        }

        static async Task<Track> GetTrackAsync(string path)
        {
            Track track = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                track = await response.Content.ReadAsAsync<Track>();
            }
            return track;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:7190/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var track = await GetTrackAsync("MusicMixer");
                ShowTrack(track);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
