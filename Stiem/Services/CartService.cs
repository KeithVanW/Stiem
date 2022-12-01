using Newtonsoft.Json;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Stiem.Services
{
    public class CartService
    {
        private readonly UserService _userService;

        public CartService(UserService userService)
        {
            _userService = userService;
        }

        public async Task<ICollection<Game>> GetGamesInCartAsync()
        {
            string url = "https://localhost:5000/api/Cart";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new
                System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer", _userService.JsonWebToken);

            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ICollection<Game>>(json);
                return result;
            }
            return null;
        }

        public async Task AddGameToCart(int gameID)
        {
            string url = "https://localhost:5000/api/Cart";

            HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new
                System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer", _userService.JsonWebToken);

            StringContent content = new StringContent(
                JsonConvert.SerializeObject(gameID),
                Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            // if badrequest check -> already in DB

        }

        public async Task RemoveFromCart(int gameID)
        {
            string url = "https://localhost:5000/api/Cart/";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new
                System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer", _userService.JsonWebToken);

            HttpResponseMessage response = client.DeleteAsync(url+gameID).Result;

        }
    }
}
