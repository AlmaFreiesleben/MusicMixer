using System.Net.Http.Headers;
using ConsoleTables;

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

        private static void ShowTrack(Track track)
        {            
            var table = new ConsoleTable("Artist", "Title", "Description", "Goes With");
            string goesWith = String.Join(", ", track.IsGoodWith.Select(p => p));
            table.AddRow(track.Artist, track.Title, track.Description, goesWith);

            table.Write(Format.Alternative);
            Console.WriteLine();
        }

        private static async Task<Track> GetTrackAsync(string path)
        {
            Track track = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                track = await response.Content.ReadAsAsync<Track>();
            }
            return track != null ? track : throw new Exception();
        }

        public static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        private static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://localhost:7190/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var track = await GetTrackAsync("MusicMixer/get_random_track");
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
