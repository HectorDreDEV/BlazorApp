using BlazorApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "http://40.82.214.146/";

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> Create(UserModel model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var httpResponse = await _httpClient
                    .PostAsync(ApiUrl + $"user", stringContent);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var errorMessage = await httpResponse.Content.ReadAsStringAsync();

                    throw new Exception(errorMessage);
                }

                var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var rs = (JsonConvert.DeserializeObject<int>(content));
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(string id)
        {
            try
            {
                var httpResponse = await _httpClient
                    .DeleteAsync(ApiUrl + $"user/{id}");

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var errorMessage = await httpResponse.Content.ReadAsStringAsync();

                    throw new Exception(errorMessage);
                }

                var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var rs = (JsonConvert.DeserializeObject<int>(content));
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserModel> GetById(string id)
        {
            try
            {                
                var httpResponse = await _httpClient
                    .GetAsync(ApiUrl + $"user/{id}");

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var errorMessage = await httpResponse.Content.ReadAsStringAsync();

                    throw new Exception(errorMessage);
                }

                var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var rs = (JsonConvert.DeserializeObject<UserModel>(content, settings));
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserModel>> GetUsers()
        {
            try
            {
                var httpResponse = await _httpClient
                    .GetAsync(ApiUrl + "user");

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var errorMessage = await httpResponse.Content.ReadAsStringAsync();

                    throw new Exception(errorMessage);
                }

                var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var rs = (JsonConvert.DeserializeObject<List<UserModel>>(content, settings)).ToList();

                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Update(UserModel model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var httpResponse = await _httpClient
                    .PutAsync(ApiUrl + $"user", stringContent);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var errorMessage = await httpResponse.Content.ReadAsStringAsync();

                    throw new Exception(errorMessage);
                }

                var content = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                var rs = (JsonConvert.DeserializeObject<int>(content));
                return rs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
