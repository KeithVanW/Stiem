using Newtonsoft.Json;
using System.Text;

namespace Stiem.Services
{
    public class UserService
    {
        public string JsonWebToken = "";

        public async Task<bool> Login(User user)
        {
            string url = "https://localhost:5000/api/Auth/login";
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(user),
                Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                string token = await response.Content.ReadAsStringAsync();
                LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(token);
                JsonWebToken = loginResponse.Token;
            }
            catch (HttpRequestException ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Register(RegisterUser user)
        {
            string url = "https://localhost:5000/api/Auth/register";
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(user),
                Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }

                string token = await response.Content.ReadAsStringAsync();
                LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(token);
                JsonWebToken = loginResponse.Token;
            }
            catch (HttpRequestException ex)
            {
                return false;
            }
            return true;
        }
    }
}