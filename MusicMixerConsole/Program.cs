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

    public class Program
    {
        static HttpClient client = new HttpClient();

        public static void Main(string[] args)
        {
            if (args.Length == 0) { RunAsync().GetAwaiter().GetResult(); }
            else 
            {
                int num = int.Parse(args[0]);
                RunAsync(num).GetAwaiter().GetResult();
            }
        }

        private static async Task RunAsync(int numberOfTracks)
        {
            client.BaseAddress = new Uri("https://localhost:7190/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                ConsoleTable table = InitiateTable();
                for (int i = 0; i < numberOfTracks; i++) 
                {
                    var track = await GetTrackAsync("MusicMixer/get_random_track");
                    AddTrackToTable(table, track);
                }
                ShowTrackTable(table);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        private static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://localhost:7190/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                ConsoleTable table = InitiateTable();
                var tracks = await GetListOfTracksAsync("MusicMixer/get_random_music_mix");
                tracks.ToList().ForEach(t => AddTrackToTable(table, t));
                ShowTrackTable(table);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        private static ConsoleTable InitiateTable()
        {            
            return new ConsoleTable("Artist", "Title", "Description", "Goes With");
        }

        private static void AddTrackToTable(ConsoleTable table, Track track)
        {            
            string goesWith = String.Join(", ", track.IsGoodWith.Select(p => p));
            table.AddRow(track.Artist, track.Title, track.Description, goesWith);
        }

        private static void ShowTrackTable(ConsoleTable table)
        {            
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

        private static async Task<IEnumerable<Track>> GetListOfTracksAsync(string path)
        {
            IEnumerable<Track> tracks = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                tracks = await response.Content.ReadAsAsync<IEnumerable<Track>>();
            }
            return tracks != null ? tracks : throw new Exception();
        }
    }
}
