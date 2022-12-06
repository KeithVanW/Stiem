﻿using Newtonsoft.Json;
using System.Text;

namespace Stiem.Services
{
    public class UserService
    {
        // eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoicGlldDEyMyIsImp0aSI6IjFmZDFmNWI5LTVhN2ItNDk3ZC04ZWQ3LTYzYjQ5NGRkN2M4NCIsImV4cCI6MTY2OTg5OTA3MiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAwIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo0MjAwIn0.e36mmN2t23PCx3NO83mFsS-PifxtU8caQwG-xxz0-Wk
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