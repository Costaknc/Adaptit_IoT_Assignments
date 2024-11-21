using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IoT_Backend_Assignment
{
    public interface IIPInfoProvider
    {
        IIpDetails GetDetails(string ip);
    }

    public interface IIpDetails
    {
        String City { get; set; }

        String Country { get; set; }

        String Continent { get; set; }

        double Latitude { get; set; }

        double Longitude { get; set; }

    }

    public class IpDetails : IIpDetails
    {
        [JsonPropertyName("city")]
        public String City { get; set; }

        [JsonPropertyName("country_name")]
        public String Country { get; set; }

        [JsonPropertyName("continent_name")]
        public String Continent { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }

    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IIpDetails> GetIpDetails(string ip)
        {
            var url = $"http://api.ipstack.com/{ip}?access_key=80193305d5b2b857d2d80ce89b8dceb4";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var responseData = JsonSerializer.Deserialize<IpDetails>(jsonResponse);

            return responseData;
        }
    }

    public class IPInfoProvider : IIPInfoProvider
    {
        private readonly ApiClient _apiClient;

        public IPInfoProvider()
        {
            _apiClient = new ApiClient();
        }

        public IIpDetails GetDetails(string ip)
        {
            var task = _apiClient.GetIpDetails(ip);
            task.Wait();
            return task.Result;
        }
    }
}
