using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HadithAPI.Controllers
{

    public class HadithService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://hadithapi.com/api";
        private const string ApiKey = "$2y$10$BylaBcXs5Lw7ZOtYmQ3PXO1x15zpp26oc1FeGktdmF6YeYoRd88e";

        public HadithService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<JsonElement?> GetBooksAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/books?apiKey={ApiKey}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var parsed = JsonDocument.Parse(json);
                return parsed.RootElement.GetProperty("books");
            }
            return null;
        }

        public async Task<JsonElement?> GetChaptersAsync(string bookSlug)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{bookSlug}/chapters?apiKey={ApiKey}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var parsed = JsonDocument.Parse(json);
                return parsed.RootElement.GetProperty("chapters");
            }
            return null;
        }

        public async Task<JsonElement?> GetHadithsAsync(string bookSlug, string chapter)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/hadiths?apiKey={ApiKey}&book={bookSlug}&chapter={chapter}&paginate=100000");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var parsed = JsonDocument.Parse(json);
                return parsed.RootElement.GetProperty("hadiths").GetProperty("data");
            }
            return null;
        }
    }

}
