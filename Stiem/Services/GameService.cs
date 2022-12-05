using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Stiem.Services
{
    public class GameService
    {
        public async Task<ICollection<Game>> GetAllGames()
        {
            string url = "https://localhost:5000/api/Game";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ICollection<Game>>(json);
                return result;
            }
            return null;
        }

        // api/search

        public async Task AddGame()
        {
            string url = "https://localhost:5000/api/Game";
            Game game = new Game()
            {
                Name = "Doom",
                Price = 15.99,
                Developer = "dink",
                ImageURL = "idk",
                Platform = "pc",
                Genre = "dink",
                Description = "ja"
            };

            string json = JsonConvert.SerializeObject(game);

            HttpClient client = new HttpClient();
            var response = await client.PostAsJsonAsync(url, game);
        }

        public async Task<ICollection<Game>> SearchByName(string nameParam)
        {
            string url = "https://localhost:5000/api/Game/search/" + nameParam;

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ICollection<Game>>(json);
                return result;
            }
            return null;
        }

        public async Task<ICollection<Game>> SearchByGenre(string genreParam)
        {
            string url = "https://localhost:5000/api/Game/genre/" + genreParam;

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ICollection<Game>>(json);
                return result;
            }
            return null;
        }
    }
}